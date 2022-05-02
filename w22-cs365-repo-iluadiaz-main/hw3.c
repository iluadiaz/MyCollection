#include <sys/types.h>
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/wait.h>
#include <string.h>
#include <ctype.h>

const char* PIPE = "|";
const char* REDIRECT = ">";
const char* SPACE = " ";

const int WRITE = 1; //write
const int READ = 0;  //read

struct Pipe
{
    int rw_pipe[2];
};


void close_pipes(const int num_commands, struct Pipe *pipes);
void execute(const char *command, const int num_args, int read_pipe[2], int write_pipe[2], struct Pipe *pipes);
void init_pipes(const int num_commands, struct Pipe *pipes);
void wait_for_all(const int num_commands);

size_t split(const char* delimiter, const char* command, char** commands);
void trim(char* str);

int main(int argc, char* argv[])
{
    char command[1024];
    char* commands[64];
    struct Pipe *pipes;

    printf("$ ");
    fgets(command, 1024, stdin);

    size_t num_commands = split(PIPE, command, commands);
    
    while (strcmp(command, "quit\n") != 0)
    {
        size_t num_commands = split(PIPE, command, commands);

        pipes = malloc(sizeof(struct Pipe) * num_commands - 1);
        init_pipes(num_commands - 1, pipes);

        printf("You typed in: %s\n", command);

        size_t i;

        if(num_commands == 1)
        {
            execute(commands[0], num_commands, NULL, NULL, pipes);
        }
        else
        {
            for(i = 0; i < num_commands; ++i)
            {
                if(i == 0)
                {
                    execute(commands[i], num_commands, NULL, pipes[i].rw_pipe, pipes);
                }
                else if(i == num_commands -1)
                {
                    execute(commands[i], num_commands, pipes[i -1].rw_pipe, pipes[i].rw_pipe, pipes );
                }
                else
                {
                //middle command
                }
        }
            close_pipes(num_commands - 1, pipes);
    }


    wait_for_all(num_commands);
    free(pipes);
    printf("$ ");
    fgets(command, 1024, stdin);
}

    return 0;
}

void close_pipes(const int num_pipes, struct Pipe *pipes)
{
    size_t i;
    for(i = 0; i < num_pipes; ++i)
    {
        if(close(pipes[i].rw_pipe[WRITE]) == -1 || pipes[i].rw_pipe[READ] == -1)
        {
            perror("Pipe destruction failed\n");
        }
    }
}
void execute(const char *command, const int num_commands, int read_pipe[2], int write_pipe[2], struct Pipe *pipes)
{
    pid_t pid;
    char *command_with_args[64];
    size_t num_args = split(SPACE, command, command_with_args);

    switch(pid = fork())
    {
        case -1:
            perror("Fork failed\n");
            break;
        case 0:
            if(read_pipe != NULL)
            {
                if(dup2(read_pipe[READ], STDIN_FILENO) < 0)
                {
                   perror("Failed to redirect STDIN\n");
                   exit(EXIT_FAILURE);
               }
            }


            if(write_pipe != NULL)
            {
                if(dup2(write_pipe[WRITE], STDOUT_FILENO) < 0)
                {
                    perror("Failed to redirect STDIN\n");
                    exit(EXIT_FAILURE);
                }
            }

            close_pipes(num_commands - 1, pipes);
            execvp(command_with_args[0], command_with_args);
            perror("Error executing comman\n");
            exit(EXIT_FAILURE);
            break;

            //default:
    }
}

void init_pipes(const int num_pipes, struct Pipe *pipes)
{
    size_t i;
    for(i = 0; i < num_pipes; ++i)
    {
        if(pipe(pipes[i].rw_pipe) < 0)
        {
            perror("Pipe initialization failed\n");
        }
    }
}

void wait_for_all(const int num_commands)
{
    size_t i;

    for(i = 0; i < num_commands; ++i)
    {
        wait(NULL);
    }
}

size_t split(const char* delimiter, const char* command, char** commands)
{

    char *token;
    char* command_copy = strdup(command);

    size_t num_commands = 0;
   
   /* get the first token */
   token = strtok(command_copy, delimiter);
   
   /* walk through other tokens */
   while( token != NULL ) {
      //printf( " %s\n", token );
      commands[num_commands] = malloc(sizeof(char) * strlen(token));
      trim(token);
      strcpy(commands[num_commands++], token);
    
      token = strtok(NULL, delimiter);
   }

    commands[num_commands] = NULL;
   return num_commands;
}



void trim(char* str)
{
    char *pstr = str;
    int len = strlen(str);

    while (isspace(pstr[len - 1]))
    {
        pstr[--len] = '\0';
    }

    while (*pstr && isspace(*pstr))
    {
        ++pstr;
        --len;
    }

    memmove(str, pstr, len + 1);
}
