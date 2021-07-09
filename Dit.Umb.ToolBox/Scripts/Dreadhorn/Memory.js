/*  Autor: Laurin Graf
*   Datum: 22.03.2019
*   Version: 3.1
*
*
*   Dies ist mein Memory Spiel
*   Es hat mehrere Redundante Stellen, darum habe ich nur die erste Stelle kommentiert
*
*
*/
//----------------------------------- Deklaration -------------------------------------
//Anzahl Spieler
let player = 1;
let playeractiv = 0;

//Array mit den Punkten der Spieler
var counter = [];

//Anzahl gedreter Kärtchen
let gedreht = 0;

//Wieviele Paare sind noch vorhanden?
let paar = 8;

//Uberprüfung, ob Karten gleich sind
let id1 = null;
let id2 = null;
let alt1 = null;
let alt2 = null;

//Musik einbinden
let x = document.getElementById("trote"); 

//Einzelne Karten
let f11 = document.getElementById("f11");
let f12 = document.getElementById("f12");
let f13 = document.getElementById("f13");
let f14 = document.getElementById("f14");
let f21 = document.getElementById("f21");
let f22 = document.getElementById("f22");
let f23 = document.getElementById("f23");
let f24 = document.getElementById("f24");
let f31 = document.getElementById("f31");
let f32 = document.getElementById("f32");
let f33 = document.getElementById("f33");
let f34 = document.getElementById("f34");
let f41 = document.getElementById("f41");
let f42 = document.getElementById("f42");
let f43 = document.getElementById("f43");
let f44 = document.getElementById("f44");


let pickOne=[11, 12, 13, 14, 21, 22, 23, 24, 31, 32, 33, 34, 41, 42, 43, 44];

let altb = "Server";
let altb1 = "Server";
let altb2 = "Alte Strasse";
let altb3 = "Weizenfeld";
let altb4 = "Berge";
let altb5 = "Papier mit Kamera";
let altb6 = "Schreibmaschine mit Feder";
let altb7 = "Laptop mit Kaffee";
let altb8 = "Sterne";

//Random Bilder einfügen
let paare = 2*paar;
for(i=4*paar;i>2*paar;i--){
    let random = Math.floor((Math.random() * pickOne.length));
    let spalte;
    let reihe;
    let sreihe;
    let bildnr = 1;;

    console.log("random "+random);

    switch(Math.round(pickOne[random]/10)){
        case 1:
            spalte = "one ";
            reihe = pickOne[random] - 10;
            break;
        case 2:
            spalte = "two ";
            reihe = pickOne[random] - 20;
            break;
        case 3:
            spalte = "three ";
            reihe = pickOne[random] - 30;
            break;
        case 4:
            spalte = "four ";
            reihe = pickOne[random] - 40;
            break;
    }
    switch(reihe){
        case 1:
            sreihe = "rone";
            break;
        case 2:
            sreihe = "rtwo";
            break;
        case 3:
            sreihe = "rthree";
            break;
        case 4:
            sreihe = "rfour";
            break;
    }

    switch(Math.floor(paare/2+1)){
        case 1:
            altb = altb1;
            bildnr = 1;
            break;
        case 2:
            altb = altb2;
            bildnr = 2;
            break;
        case 3:
            altb = altb3;
            bildnr = 3;
            break;
        case 4:
            altb = altb4;
            bildnr = 4;
            break;
        case 5:
            altb = altb5;
            bildnr = 5;
            break;
        case 6:
            altb = altb6;
            bildnr = 6;
            break;
        case 7:
            altb = altb7;
            bildnr = 7;
            break;
        case 8:
            altb = altb8;
            bildnr = 8;
            break;
    };

    console.log(spalte);
    console.log(sreihe);
    document.getElementById("karten").innerHTML = document.getElementById("karten").innerHTML + "<div id='f" + pickOne[random] + "' class='feld " + spalte + sreihe + "'><div><img src='../../css/Dreadhorn/Memorybilder/bild"+bildnr+".jpg' alt='"+altb+"'></div></div>";
    paare = paare - 1;

    pickOne.splice(random, 1);
    console.log("i: "+i);
    console.log("lenght: " + pickOne.length);

}




//-------------------------------------- Start (nur ein Mal) ------------------------------
// Versteckt alle Bilder
$(".feld>div").hide();

//Anzahl an Spieler wird erfragt
player = prompt("Wie viele Spieler Spielen mit?");

if(player==null||player==""){ //Wird kein Wert eingegeben wird mir einem Spieler gespielt
    player=1;
}

for(i = 0; i<player; i++){ // Forschleife für die Spieler
    counter[i] = 0; //Erstellt Array mit den spielern und Punkten

    //Fügt ein neues Div in den Aside hinzu
    //In diesem Div steht der Spieler und die Punkte des Spielers
    document.getElementById("anzeige").innerHTML = document.getElementById("anzeige").innerHTML + "<div id='spieler"+i+"' class='spieler'>Spieler "+ (i+1) +": "+counter[i]+"<br></div>";
}

$(document.getElementById("spieler"+playeractiv)).css("color", "red"); //Setzt den ersten Spieler auf rot

//-------------------------------------- Toggle -------------------------------------------

//Erste Zeile
$("#f11").on("click", function(){ //Bei einem Klick auf eine Karte
    if(gedreht==2){ //Sind schon zwei karten gedreht?
        //Zwei zarten sind schon gedreht, es passiert nichts
    }else{
        gedreht++; //Eine weitere Karte wurde gedreht
        $("#f11>div").fadeToggle(1000); //Dreht die Karte um
        
        //Schreibt die ID der Karte in die freie Variable
        if(id1 == null){ //Ist Variable ID1 frei?
            id1 = $("#f11").attr("id"); //Schreibt Id der Karte in ID1
             }else if(id2 == null){ ///Ist die Variable ID2 frei?
            id2 = $("#f11").attr("id"); //Schreibt ID der Karte in ID2
             }
             //Schreibt den Alternatievtext des Bildes in die frei Variable
        if(alt1 == null){ //Ist die Variable alt1 frei
            alt1 = $("#f11").children().children().attr("alt"); //schreibt den Alt in die Variable Alt1
            }else if(alt2 == null){//Ist die Variable alt2 frei
            alt2 = $("#f11").children().children().attr("alt"); //schreibt den Alt in die Variable Alt2
            }

        check(); //ruft Funktion aus

    }
});

$("#f12").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f12>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f12").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f12").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f12").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f12").children().children().attr("alt");
            }
        check();
    }
});

$("#f13").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f13>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f13").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f13").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f13").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f13").children().children().attr("alt");
            }
        check();
    }
});

$("#f14").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f14>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f14").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f14").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f14").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f14").children().children().attr("alt");
            }
        check();
    }

});

//Zweite Zeile
$("#f21").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f21>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f21").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f21").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f21").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f21").children().children().attr("alt");
            }
            check();
    }
});

$("#f22").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f22>div").fadeToggle(400);

         
        if(!(id1 != null)){
            id1 = $("#f22").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f22").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f22").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f22").children().children().attr("alt");
            }
        check();
    }
});

$("#f23").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f23>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f23").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f23").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f23").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f23").children().children().attr("alt");
            }
        check();
    }
});

$("#f24").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f24>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f24").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f24").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f24").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f24").children().children().attr("alt");
            }
        check();
    }
});

//Dritte Zeile
$("#f31").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f31>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f31").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f31").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f31").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f31").children().children().attr("alt");
            }
        check();
    }
});

$("#f32").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f32>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f32").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f32").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f32").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f32").children().children().attr("alt");
            }
        check();
    }
});

$("#f33").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f33>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f33").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f33").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f33").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f33").children().children().attr("alt");
            }
        check();
    }
});

$("#f34").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f34>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f34").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f34").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f34").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f34").children().children().attr("alt");
            }
        check();
    }
});

//Vierte Zeile
$("#f41").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f41>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f41").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f41").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f41").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f41").children().children().attr("alt");
            }
        check();
    }
});

$("#f42").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f42>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f42").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f42").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f42").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f42").children().children().attr("alt");
            }
        check();
    }
});

$("#f43").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f43>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f43").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f43").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f43").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f43").children().children().attr("alt");
            }
        check();
    }
});

$("#f44").on("click", function(){
    if(gedreht==2){
    }else{
        gedreht++;
        $("#f44>div").fadeToggle(400);

        if(!(id1 != null)){
            id1 = $("#f44").attr("id");
             }else if(!(id2 != null)){
            id2 = $("#f44").attr("id");
             }
        if(!(alt1 != null)){
            alt1 = $("#f44").children().children().attr("alt");
            }else if(!(alt2 != null)){
            alt2 = $("#f44").children().children().attr("alt");
            }
        check();
    }
});
//--------------------------------------------- Funktionen ------------------------------------


//Sind 2 Karten umgedreht?
function check(){
    let brufen; //Eine locale Variable zur überprüfung

    if(gedreht >= 2){ //Es sind zwei Karten gedreht

        brufen = prufen();
        if(brufen==1){ //Es ist nicht die gleiche Karte
            setTimeout(function(){

                $(document.getElementById("spieler"+playeractiv)).css("color", "black"); //Speilerfarbe auf Schwarz
                
                if(player-1==playeractiv){ //Ist es der Letzte spieler?
                    playeractiv = 0; 
                }else {
                    playeractiv +=1;}
                $(document.getElementById("spieler"+playeractiv)).css("color", "red"); //Setzt den aktuellen spieler auf Rot

            },2000);

            setTimeout(function() {
                $(".feld>div").fadeOut(1000); //Dreht alle karten um
                setTimeout(function(){
                    gedreht = 0;

                }, 1000);
            }, 3000);
        }else{

            gedreht = 0;
        }
    }
}

//Sind es die gleichen Bilder, aber nicht die gleichen Karten?
function prufen(){
    let gleich = 1;
    
    if(!(id1 != id2)){ // Es ist die gleiche Karte
        gleich = 2;
        //Setzt IDs und ALT auf "Null"
        id1 = null;
        id2 = null;
        alt1 = null;
        alt2 = null;

    }else if(alt1 == alt2){ //Beide Alternatievtexte sind gleich

        //Spielt kurze tröte und führt Funktion punkt aus
        setTimeout(function(){x.play();punkt();}, 1000);

        gleich = 0;
        setTimeout(function(){
            // Erstes Kärtchen weglegen
            switch(id1){
                //hide erste Reihe
                case "f11":
                    $("#f11").delay(1000).hide(100);
                    break;
                case "f12":
                    $("#f12").delay(1000).hide(100);
                    break;
                case "f13":
                    $("#f13").delay(1000).hide(100);
                    break;
                case "f14":
                    $("#f14").delay(1000).hide(100);
                    break;
                
                //hide zewite Reihe
                case "f21":
                    $("#f21").delay(1000).hide(100);
                    break;
                case "f22":
                    $("#f22").delay(1000).hide(100);
                    break;
                case "f23":
                    $("#f23").delay(1000).hide(100);
                    break;
                case "f24":
                    $("#f24").delay(1000).hide(100);
                    break;
                
                //hide drite Reihe
                case "f31":
                    $("#f31").delay(1000).hide(100);
                    break;
                case "f32":
                    $("#f32").delay(1000).hide(100);
                    break;
                case "f33":
                    $("#f33").delay(1000).hide(100);
                    break;
                case "f34":
                    $("#f34").delay(1000).hide(100);
                    break;
                
                //hide vierte Reihe
                case "f41":
                    $("#f41").delay(1000).hide(100);
                    break;
                case "f42":
                    $("#f42").delay(1000).hide(100);
                    break;
                case "f43":
                    $("#f43").delay(1000).hide(100);
                    break;
                case "f44":
                    $("#f44").delay(1000).hide(100);
                    break;
                default:
                    console.log("ID 2 Default");
            }

            //Zweites Kärtchen weglegen
            switch(id2){

                //hide erste Reihe
                case "f11":
                    $("#f11").delay(1000).hide(100);
                    paar--;
                    break;
                case "f12":
                    $("#f12").delay(1000).hide(100);
                    paar--;
                    break;
                case "f13":
                    $("#f13").delay(1000).hide(100);
                    paar--;
                    break;
                case "f14":
                    $("#f14").delay(1000).hide(100);
                    paar--;
                    break;
                
                //hide zewite Reihe
                case "f21":
                    $("#f21").delay(1000).hide(100);
                    paar--;
                    break;
                case "f22":
                    $("#f22").delay(1000).hide(100);
                    paar--;
                    break;
                case "f23":
                    $("#f23").delay(1000).hide(100);
                    paar--;
                    break;
                case "f24":
                    $("#f24").delay(1000).hide(100);
                    paar--;
                    break;
                
                //hide drite Reihe
                case "f31":
                    $("#f31").delay(1000).hide(100);
                    paar--;
                    break;
                case "f32":
                    $("#f32").delay(1000).hide(100);
                    paar--;
                    break;
                case "f33":
                    $("#f33").delay(1000).hide(100);
                    paar--;
                    break;
                case "f34":
                    $("#f34").delay(1000).hide(100);
                    paar--;
                    break;
                
                //hide vierte Reihe
                case "f41":
                    $("#f41").delay(1000).hide(100);
                    paar--;
                    break;
                case "f42":
                    $("#f42").delay(1000).hide(100);
                    paar--;
                    break;
                case "f43":
                    $("#f43").delay(1000).hide(100);
                    paar--;
                    break;
                case "f44":
                    $("#f44").delay(1000).hide(100);
                    paar--;
                    break;
                default:
                    console.log("ID 2 Default");
            }

            //Wenn es keine Paare mehr übrig hat
            if(paar == 0){
                setTimeout(function(){
                    alert("Du hast es geschaft!");
                }, 1200)

            }
            
            //Setzt IDs und ALT auf "Null"
            id1 = null;
            id2 = null;
            alt1 = null;
            alt2 = null;
        }, 2500);
    }else{
        //Setzt IDs und ALT auf "Null"
        id1 = null;
        id2 = null;
        alt1 = null;
        alt2 = null;
    }



    //Return gleich zur info an Check
    return gleich;
}

//Welcher Spieler bekommt ein Punkt
function punkt(){
    counter[playeractiv] += 1;
    document.getElementById("spieler"+playeractiv).textContent ="Spieler "+ (playeractiv+1) +": "+counter[playeractiv]; //Gibt die neue Punktezahl aus

}