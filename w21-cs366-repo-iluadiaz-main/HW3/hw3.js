$(document).ready(function() {
 //This is where the beautification happens
$("#top").css("borderColor", "black", "borderWidth", "10px");  
$("#top").css("background-color", "#6495ED");   
$("#navigationBar").css("background-color", "silver");
$("table").css("borderColor", "yellow");
$("tr").css("borderColor", "yellow");
$("td").css("border", "yellow");
$(".contains").css("height", 900);

//variables created in preperation for calculations
var atk;
var def;
var spa;
var spd;
var spe;

//gets a value between 1-24, skipping every 6th, that represents a nature
 function getNat()
 {
    return nature.value;
 }

 //prevent bad user input
 $("input.positive-numeric-only").on("keydown", function(e) {
    var char = e.originalEvent.key.replace(/[^0-9^.^,]/, "");
    if (char.length == 0 && !(e.originalEvent.ctrlKey || e.originalEvent.metaKey)) {
      e.preventDefault();
    }
  });

   //prevent bad user input
  $("input.positive-numeric-only").bind("paste", function(e) {
    var numbers = e.originalEvent.clipboardData
      .getData("text")
      .replace(/[^0-9^.^,]/g, "");
    e.preventDefault();
    var the_val = parseInt(numbers);
    if (the_val > 0) {
      $(this).val(the_val.toFixed(0));
    }
  });

   //prevent bad user input
  $("input.positive-numeric-only").focusout(function(e) {
    if (!isNaN(this.value) && this.value.length != 0) {
      this.value = Math.abs(parseInt(this.value)).toFixed(0);
    } else {
      this.value = 0;
    }
  });

   //Does all the math
 function runCalculator() {

//prepares nature variable for calculations
let nature = getNat();

//these are the stats taken via user input
atk = parseInt($("#ATK").val());
def = parseInt($("#DEF").val());
spa = parseInt($("#SPA").val());
spd = parseInt($("#SPD").val());
spe = parseInt($("#SPE").val());

//if statements check for conditions to accuratly alter stats
if( nature == "2")
{
    atk = atk + Math.floor((atk / 10));
    def = def - Math.floor((def / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "3")
{
    atk = atk + Math.floor((atk / 10));
    spe = spe - Math.floor((spe / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "4")
{
    atk = atk + Math.floor((atk / 10));
    spa = spa - Math.floor((spa / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "5")
{
    atk = atk + Math.floor((atk / 10));
    spd = spd - Math.floor((spd / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "6")
{
    def = def + Math.floor((def / 10));
    aatklteredStat2 = atk - Math.floor((atk / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "8")
{
    def = def + Math.floor((def / 10));
    spe = spe - Math.floor((spe / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "9")
{
    def = def + Math.floor((def / 10));
    spa = spa - Math.floor((spa / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "10")
{
    def = def + Math.floor((def / 10));
    spd = spd - Math.floor((spd / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "11")
{
    spe = spe + Math.floor((spe / 10));
    atk = atk - Math.floor((atk / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "12")
{
    spe = spe + Math.floor((spe / 10));
    def = def - Math.floor((def / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "14")
{
    spe = spe + Math.floor((spe / 10));
    spa = spa - Math.floor((spa / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "15")
{

    spe = spe + Math.floor((spe / 10));
    spd = spd - Math.floor((spd / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe);
}

if( nature == "16")
{
    spa = spa + Math.floor((spa / 10));
    atk = atk - Math.floor((atk / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe)
}

if( nature == "17")
{
    spa = spa + Math.floor((spa / 10));
    def = def - Math.floor((def / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe)
}

if( nature == "18")
{
    spa = spa + Math.floor((spa / 10));
    spe = spe - Math.floor((spe / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe)
}

if( nature == "20")
{
    spa = spa + Math.floor((spa / 10));
    spd = spd - Math.floor((spd / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe)
}

if( nature == "21")
{
    spd = spd + Math.floor((spd / 10));
    atk = atk - Math.floor((atk / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe)
}

if( nature == "22")
{
    spd = spd + Math.floor((spd / 10));
    def = def - Math.floor((def / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe)
}

if( nature == "23")
{
    spd = spd + Math.floor((spd / 10));
    spe = spe - Math.floor((spe / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe)
}

if( nature == "24")
{
    spd = spd + Math.floor((spd / 10));
    spa = spa - Math.floor((spa / 10));

    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe)
}


//array used for figuring out what purpose a pokemon can bets serve based on its newly calculated stats
var array = [atk,def,spa,spd,spe]
//sorts array
array.sort();

//variables that hold highest and second highest stat
temp = array[4];
temp2 = array[3]; 

//lets user know which natures dont do anything
if(nature == 1 || nature == 7 || nature == 13 || nature == 19 || nature == 25)
{
    $("#atkMod").html(atk);
    $("#defMod").html(def);
    $("#spcAtkMod").html(spa);
    $("#spcDefMod").html(spd);
    $("#speMod").html(spe)

    $("#suggestion").html("<p> This nature does not change any stats! </p>");
    return;
}

//If statements change html <p></p> based on suggested pokemon use
if(temp == spe && temp2 == atk || temp == atk && temp2 == spe)
{
    $("#suggestion").html("<p> This pokemon will serve best as a fast physical sweeper </p>");
}

else if(temp == spe && temp2 == spa || temp == spa && temp2 == spe)
{
    $("#suggestion").html("<p> This pokemon will serve best as a fast special sweeper </p>");
}

else if(temp == atk && temp2 != spe )
{
    $("#suggestion").html("<p> This pokemon will serve best as a physical sweeper </p>");
}

if(temp == spa && temp2 != spe)
{
    $("#suggestion").html("<p> This pokemon will serve best as a special sweeper </p>");
}

else if(temp == def  && temp2 == spd || temp == spd && temp2 == spd)
{
    $("#suggestion").html("<p> This pokemon will serve best as a damage soak</p>");
}

else if(temp == def )
{
    $("#suggestion").html("<p> This pokemon will serve best as a physical damage soak </p>");
}

else if(temp == spd )
{
    $("#suggestion").html("<p> This pokemon will serve best as a special damage soak </p>");
}

if(temp == spd && temp == atk && temp == def && temp == spe && temp == spa   )
{
    $("#suggestion").html("<p> This pokemon can serve any role </p>");
}

//end of calculating function
}
   $("#updateStats").click(function(e) {

        runCalculator();
});

});
