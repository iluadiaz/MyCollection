using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using __460A1.Models;

namespace __460A1.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Update
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateView()
        {
            return View(new Update());
        }

        //private List<calculator> speeds;
        //GET: calculator

        [HttpPost]

        public ActionResult UpdateView(Update c, string generate)
        {

            if (generate == "generateTable")
            {
                //Prepares string for parsing
                string inFront = c.frontChainSize;
                string rear = c.rearCogSize;
  
                int[] tempArray = new int[150];
         
                //will feed the 2d array
                int[][] rowList = new int[2][];
                
                //counter used for proper iteration
                int counter = 0;

                //parsing rearCogSize
                foreach (var nums in rear.Split(','))
                {
                    int number;
                    if (int.TryParse(nums, out number))
                    {
                        tempArray[counter] = number;
                        counter++;
                    }
                }              

                //update row size
                c.row = counter+1;

                //instantiate rows
                rowList[0] = new int[150];

                for (int i = 0; i < c.row; i++)
                {
                    rowList[0][i] = tempArray[i];
                }
                //reset temp array
                tempArray = new int[150];

                //reset counter
                counter = 0;

                //parsing frontCogSize
                foreach (var nums in inFront.Split(','))
                {
                    int number;
                    if (int.TryParse(nums, out number))
                    {

                        tempArray[counter] = number;
                        counter++;
                    }
                }

                //update column size
                c.column = counter+1;

                //instantiate columns
                rowList[1] = new int[150];

                //load coloumns
                for (int i = 0; i < c.column; i++)
                {
                    rowList[1][i] = tempArray[i];
                }
                //reset temp array
                tempArray = new int[150];

                //reset counter
                counter = 0;

                //load the 2d arrayy
                for (int i = 0; i < c.row; i++)
                {
                    if (counter == 2)
                        counter = 0;

                        for (int j = 0; j < c.column; j++)
                    {
                        c.theTable[j, i] = rowList[counter][j];

                    }
                    counter++;
                }
            }
            return View(c);
        }

    }
}
    