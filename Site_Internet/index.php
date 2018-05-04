<!DOCTYPE html>
<html lang="fr">
<head>
	<meta charset="UTF-8">
	<title>Patrick Fouquet portfolio - programmeur</title>
	<link rel="stylesheet" type='text/css' href="style/style.css">
	<link rel="icon" type="image/png" href="images/favicon.png">
	<link rel="icon" type="image/icon" href="images/favicon.ico">
	<link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico">

	<meta name="author" content="Patrick Fouquet" />
	<meta name="copyright" content="Patrick Fouquet 2014" />
	<meta name="description" content="Portfolio de Patrick Fouquet, programmeur" />
	<meta name="keyword" content="portfolio, patrick, fouquet, programmeur, infographiste, internet, bon" />
	<meta name="viewport" content="width=device-width, user-scalable=no" />
	
	<!-- Open graph meta -->
	<meta property="og:title" content="Bienvenue sur le portfolio de Patrick Fouquet" />
    <meta property="og:type" content="article" />
    <meta property="og:url" content="http://techniquesmedia.com/12fouquetp/portfolio/" />
    <meta property="og:image" content="http://techniquesmedia.com/12fouquetp/portfolio/ascreen.jpg" />
	<!-- Fin open graph meta -->

	<script type="text/javascript" src="js/jquery-1.11.1.min.js"></script><!-- Insertion de la bibliotheque jQuery -->
    <script type="text/javascript" src="js/aime.js"></script>

    <script type="text/javascript" src="js/plugins.js"></script>
	<script type="text/javascript" src="js/sly.min.js"></script>
    <script type="text/javascript" src="js/horizontal.js"></script>
	
	<!-- Add mousewheel plugin (this is optional) -->
	<script type="text/javascript" src="js/jquery.mousewheel-3.0.6.pack.js"></script>

	<!-- Add fancyBox -->
	<link rel="stylesheet" href="style/jquery.fancybox.css?v=2.1.5" type="text/css" media="screen" />
	<script type="text/javascript" src="js/jquery.fancybox.pack.js?v=2.1.5"></script>
	


	<!--[if lt IE 9]>
	<script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->
	<script type="text/javascript">
	$(document).ready(function(){
	    	$(".fancybox").fancybox();
		$('a[href^="#"]').on('click',function (e) {
		        e.preventDefault();

		        var target = this.hash,
		        $target = $(target);

		        $('html, body').stop().animate({
		            'scrollTop': $target.offset().top
		        }, 900, 'swing', function () {
		            window.location.hash = target;
		        });
		});

		$(window).scroll(function(){
		  if ($(this).scrollTop() > 445) {
		   $('#competance td').css({
		      "opacity": '1', 
		      "-webkit-animation-play-state": 'running',
		      "animation-play-state": 'running'
		    });
		  } 
		});
	});
	</script>
	
</head>
<body>
<div id="moi"></div>
	<div id="grille">
	<header>
		<nav>
			<ul>
				<li><a href="#Accueil">Accueil</a></li>
				<li><a href="#Profil">Profil</a></li>
				<li><a href="#Galerie">Galerie</a></li>
				<li><a href="#Contact">Contact</a></li>
			</ul>
			<!--<div id="petite_bar"></div>-->
		</nav>
	</header>
	<div class="wrapper">
		<section id="Accueil">
			<img src="images/photo.png" width="618" height="530" alt="Une petite photo de moi">
			<hgroup>
				<h1>Patrick Fouquet</h1>
				<h2>Programmeur</h2>
			</hgroup>
		</section>
		<section id="Profil">
			<h1>Profil</h1>
			<article>
				<iframe src="//www.youtube.com/embed/82UVkMdowGA" frameborder="0" allowfullscreen></iframe>
			</article>
			<article>
				<table id="competance">
					<tr>
						<th>HTML5</th><td></td><td></td><td></td><td></td><td></td>
					</tr>
					<tr>
						<th>CSS3</th><td></td><td></td><td></td><td></td>
					</tr>
					<tr>
						<th>PHP</th><td></td><td></td><td></td><td></td><td></td>
					</tr>
					<tr>
						<th>JS/jQuery</th><td></td><td></td><td></td>
					</tr>
					<tr>
						<th>C#</th><td></td><td></td><td></td>
					</tr>
					<tr></tr>
					<tr>
						<th>3D</th><td></td><td></td><td></td>
					</tr>
					<tr>
						<th>Illustrator</th><td></td><td></td><td></td><td></td>
					</tr>
					<tr>
						<th>Photoshop</th><td></td><td></td><td></td>
					</tr>
				</table>
			</article>
			<p class="description">Je suis Patrick Fouquet, j'étudie depuis maintenant 3 ans au cégep de Jonquière en techniques d'intégration multimédia, où j'ai appris à faire des sites internet complets et à travailler en équipe. De plus, j'ai étudié durant un certain temps en informatique au cégep de Chicoutimi.</p>

			<p class="description">J'ai appris de nombreux langages de programmation et différents logiciels durant mes études. Je me suis spécialisé dans la programmationJe suis en mesure de faire de beaux designs de site internet, de la vidéo, du montage sonore et même de l'animation 3D.</p>
			
			<article>
				<table class="aime">
				<tr>
					<td><img id="n0" src="images/chien.png" width="80" height="80" alt="Un icone représentant un chien"/></td>
					<td><img id="n1" src="images/film.png" width="80" height="80" alt="Un icone représentant une bomine de film"/></td>
					<td><img id="n2" src="images/jeuxvideo.png" width="80" height="80" alt="Un icone représentant une mannete de jeux vidéo"/></td>
					<td><img id="n3" src="images/astronomie.png" width="80" height="80" alt="Un icone représentant une personne avec un télescope"/></td>
					<td><img id="n4" src="images/japon.png" width="80" height="80" alt="Un icone représentant un onigiri"/></td>
					<td><img id="n5" src="images/lecture.png" width="80" height="80" alt="Un icone représentant une personne en train de lire un livre"/></td>
					<td><img id="n6" src="images/ordinateur.png" width="80" height="80" alt="Un icone représentant un ordinateur"/></td>
					<td><img id="n7" src="images/relaxer.png" width="80" height="80" alt="Un icone représentant une personne qui médite"/></td>
					<td><img id="n8" src="images/dessiner.png" width="80" height="80" alt="Un icone représentant une plume"/></td>
				</tr>
				<tr>
					<td colspan=9><p id="text">J'aime la culture japonaise, les mangas et les sushis par exemple</p></td>
				</tr>
				</table>
			</article>
		</section>
		<section id ="Galerie">
			<h1>Galerie</h1>

			<div class="scrollbar">
				<div class="handle">
					<div class="mousearea"></div>
				</div>
			</div>

			<div class="frame oneperframe" id="oneperframe">
				<ul class="clearfix">
					<li>
						<div class="scroller-el">
							<a class="fancybox" rel="programation" href="images/carte_chaton_grande.png" ><img src="images/carte_chaton.jpg" width="250" height="180" alt="Cartes de Chaton" border="0" /></a>
							<article>
								<h3>2013</h3><h3>Programmation</h3>
								<p>
									Sur ce projet scolaire, j'ai dû programmer en PHP l'envoi d'une carte construite dynamiquement ainsi qu'un CMS fonctionnel.<br>
									<a href="http://techniquesmedia.com/12fouquetp/carte/" target="_blanc" class="desactiver">Lien</a>
								</p>
							</article>
						</div>
						<div class="scroller-el">
							<a class="fancybox" rel="programation" href="images/ballon_grand.jpg" ><img src="images/ballon.jpg" width="250" height="180" alt="Jeu pour e^xploser des ballon" border="0" /></a>
							<article>
								<h3>2014</h3><h3>Programmation</h3>
								<p>
									Un jeu réalisé avec le logiciel flash, dans le cours d'interactivité vectorielle. Le but, faire exploser des ballons en bougeant la souris.<br>
									<a href="jeux/ballons.html" target="_blanc" class="desactiver">Lien</a>
								</p>
							</article>
						</div>
						<div class="scroller-el">
							<a class="fancybox" rel="programation" href="images/labyrinthe_grande.jpg" ><img src="images/labyrinthe.jpg" width="250" height="180" alt="Jeux ou il faut sortir d'un labyrinthe" border="0" /></a>
							<article>
								<h3>2014</h3><h3>Programmation</h3>
								<p>
									Un jeu réalisé avec le logiciel flash, dans le cours d'interactivité vectorielle. Le but, est de sortir d'un petit labyrinthe sans mourir. <br>
									<a href="jeux/labyrinthe.html" target="_blanc" class="desactiver">Lien</a>
								</p>
							</article>
						</div>
					</li>
					<li>
						<div class="scroller-el">
							<a class="fancybox" rel="programation" href="images/bombe_grande.jpg" ><img src="images/bombe.jpg" width="250" height="180" alt="Panique, il faut désamorcer les bombes" border="0" /></a>
							<article>
								<h3>2014</h3><h3>Programmation</h3>
								<p>
									Un jeu réalisé avec le logiciel flash, dans le cours d'interactivité vectorielle. Le but, est d'aller désamorcer toutes les bombes avant la fin du temps imparti<br>
									<a href="jeux/bombe.html" target="_blanc" class="desactiver">Lien</a>
								</p>
							</article>
						</div>
						<div class="scroller-el">
							<a class="fancybox" rel="programation" href="images/mythologie_grande.jpg" ><img src="images/mythologie.jpg" width="250" height="180" alt="Un site sur la mythologie nordique" border="0" /></a>
							<article>
								<h3>2014</h3><h3>Programmation</h3>
								<p>
									Voici mon projet final du cours de création multimédia, un site internet entièrement responsive.<br>
									<a href="http://techniquesmedia.com/12fouquetp/mythologie/" target="_blanc">Lien</a>
								</p>
							</article>
						</div>
						<div class="scroller-el">
							<a class="fancybox" rel="photoshop" href="images/design_grande.jpg" ><img src="images/design.jpg" width="250" height="180" alt="Un montage photoshop avec un ours" border="0" /></a>
							<article>
								<h3>2013</h3><h3>Infographie</h3>
								<p>
									Ceci est l'interface d'un site internet que j'ai du réaliser dans le cours d'ergonomie. Le sujet était l'écologie.
								</p>
							</article>
						</div>
					</li>
					<li>
						<div class="scroller-el">
							<a class="fancybox" rel="photoshop" href="images/paysage_grande.jpg" ><img src="images/paysage.jpg" width="250" height="180" alt="Un petit homme qui marche sur une prairie" border="0" /></a>
							<article>
								<h3>2014</h3><h3>Photoshop</h3>
								<p>
									Cette image a été montée dans le cadre d'un cours de Photoshop où il fallait créer un paysage imaginaire. On se sent tout petit en la voyant.
								</p>
							</article>
						</div>
						<div class="scroller-el">
							<a class="fancybox" rel="photoshop" href="images/ours_grande.jpg" ><img src="images/ours.jpg" width="250" height="180" alt="Un montage photoshop avec un ours" border="0" /></a>
							<article>
								<h3>2013</h3><h3>Photoshop</h3>
								<p>
									Voici un projet personnel réalisé sur Photoshop, à partir de la photo d'un ours. Je l'utilise sur ma page, <a target="blanck" href="https://www.facebook.com/patrick.fouquet.77" title="Facebook">Facebook</a>.
								</p>
							</article>
						</div>
						<div class="scroller-el">
							<a class="fancybox" rel="photoshop" href="images/agenda_grande.jpg" ><img src="images/agenda.jpg" width="250" height="180" alt="Une belle couverture pour un agenda scolaire" border="0" /></a>
							<article>
								<h3>2012</h3><h3>Photoshop</h3>
								<p>
									Cette couverture pour un agenda a été réalisée dans le but de gagner un concours, la compétition était féroce.
								</p>
							</article>
						</div>
					</li>
					<li>
						<div class="scroller-el">
							<a class="fancybox" rel="programation" href="images/code_grande.png" ><img src="images/code.jpg" width="250" height="180" alt="Un code en js que j'ai fait" border="0" /></a>
							<article>
								<h3>2014</h3><h3>Programmation</h3>
								<p>
									Voici un JavaScript que j'ai réalisé pour ce portfolio. Il est utilisé dans la section "Profil" sur les choses que j'aime.<br>
									<a href="js/aime.js" target="_blanc" class="desactiver">Lien</a>
								</p>
							</article>
						</div>
						<div class="scroller-el">
							<a class="fancybox" rel="programation" href="images/jeu1.png" ><img src="images/jeu1.png" width="250" height="180" alt="Un site explicatif sur le jeu unity" border="0" /></a>
							<article>
								<h3>2014</h3><h3>Programmation</h3>
								<p>
									Ceci est la version Alpha du jeu Unity fait avec mon équipe. Je suis chargé de la programmation du décors et c'est moi le responsable pour les ballons. <br>
									<a href="Ner_D_Boy/Ner_D_Boy.html" target="_blanc" class="desactiver">Lien</a>
								</p>
							</article>
						</div>
						
					</li>

				</ul>
			</div>

			<div class="controls center">
				<button class="btn prev"><i class="icon-chevron-left"></i></button>
				<button class="btn next"><i class="icon-chevron-right"></i></button>
			</div>

		</section>
		<section id="Contact">
			<h1>Contact</h1>
			<article>
				<table id="lien">
					<tr>
						<td class="click"><a target="blanck" href="Patrick_Fouquet_CV.pdf" title="Mon Curriculum Vitae"><img src="images/curriculum1.png" width="100" height="100" border="0" /></a></td>
						<td></td>
						<td></td>
					</tr>
					<tr>
						<td></td>
						<td class="click"><a target="blanck" href="https://www.facebook.com/patrick.fouquet.77" title="Facebook"><img src="images/facebook1.png" width="100" height="100" border="0" /></a></td>
						<td></td>
					</tr>
					<tr>
						<td></td>
						<td></td>
						<td class="click"><a href="mailto:patouk342@hotmail.fr" title="Courriel"><img src="images/arroba2.png" width="100" height="100" border="0" /></a></td>
					</tr>
					
				</table>
			</article>
			<?php
			            $email=$_POST["email"];
			            $nom=$_POST["nom"];
			            $message=$_POST["message"];
			            if (!empty($email)||!empty($nom)||!empty($message))
			            {
			                require("class.phpmailer.php");

			                $mail = new PHPMailer();
			                $mail->CharSet = "utf-8";

			                $mail->From     = "Portfolio";
			                $mail->FromName = "Portfolio";

			                $mail->Subject  = "$nom - $email";
			                $mail->Body     = "$message";

			                $mail->AddAddress('patouk342@hotmail.fr');

			                if(!$mail->Send()) {
			                      echo "Le message n'a pas été envoyé.";
			                      echo 'Mailer error: ' . $mail->ErrorInfo;
			                    } else {
			                        echo '<script type="text/javascript">';
			                        echo 'alert("Le Message a été envoyé.")';
			                        echo '</script>';
			                    }
			                }
			            ?>
			<form method="post" action="index.php" name='formulaireContact'>
				<fieldset>
					<input type="text" name="nom" id="nom" size="25em" placeholder="Nom" required/><br />
					<input type="email" name="email" id="email" size="25em" placeholder="Courriel" required/><br />
					
					<textarea rows="10" name="message" id="message" placeholder="Message" required></textarea><br />
					
					<input type="submit" id="envoyer" value="Envoyer" />
				</fieldset>
			</form>
		</section>
		<div class="copyright">
			<p >Tous droits réservés Patrick Fouquet &copy; 2014</p>
			<p>Icônes fait par Freepik, Icons8 sur <a target="blanck" href="http://www.flaticon.com" title="Flaticon">www.flaticon.com</a> est licencié par <a target="blanck" href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0">CC BY 3.0</a></p>
		</div>
	</div><!-- Fin de wrapper -->
	</div><!-- Fin de grille -->
<div id="contact"></div>
</body>
</html>