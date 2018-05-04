$(document).ready(function(){

  var MonTableau = [" J'aime mes deux chiens et les animaux en général ",
    " J'aime regarder des films, surtout ceux d'actions ",
    " J'aime jouer aux jeux vidéo, les rpg sont mes préférés ",
    " J'aime apprendre comment fonctionne l'univers dans les documantaires ",
    " J'aime la culture japonaise, les mangas et les sushis par exemple ",
    " J'aime lire des romans de Science-Fiction et de fantastique ",
    " J'aime tout ce qui touche aux ordinateurs et à l'informatique ",
    " J'aime relaxer et ne pas me prendre la tête pour rien ",
    " J'aime gribouiller des personnages sur le coin des feuilles "];

  var icone = 4;
  var i2 = 9;
  var IntID = setTimer();

  function modif( no ){
    return function(){

//Cette partie de la fonction sert a modifier le css pour grossir et réduire la taille des icône.
    if(i2<9)
    $("#n"+i2).css("transform", "scale(0.75, 0.75)");

    $("#n"+no).css("transform", "scale(1, 1)");
    //$("#n"+i).css("-webkit-filter", "drop-shadow(0 0 2px #fff)");

//Cici sert a modifier le texte avec un effet de fondu
    $("#text").fadeOut(500, function() {
      $(this).fadeIn(500);
      $(this).html("«"+MonTableau[no]+"»");
    });
    
    i2 = no;
    icone = no;

    clearInterval(IntID);
    IntID = setTimer();
    }
  }
//Si l'utilisateur click sur une icône rappeler la fonction modif ce qui réinitialise le timer.
  for(var i = 0; i<MonTableau.length; i++) {
    $('#n' + i).click( modif( i ) );
  }
  $(modif( icone ));
//Le timer qui compte jusqu'à dix seconde avant d'envoyer le numéro de l'icône à midifier
  function setTimer(){
     timer = setInterval(function() { 
     if(icone < MonTableau.length-1)
        icone++;
      else
        icone = 0;
      $(modif( icone ));
    }, 10000);
     return timer;
  }
});