/* Author:

*/
$(document).ready( 
	function(){
		var comics = [
			{ 
				imgSrc : "cover1.jpg",
				title : "Captain Templates",
				year : "2010",
				number : "1"
			},			  
			{ 
				imgSrc : "cover2.jpg",
				title : "Captain Templates",
				year : "2011",
				number : "2"
			},			  
			{ 
				imgSrc : "cover3.jpg",
				title : "Captain Templates",
				year : "2012",
				number : "3"
			}	  			  
		]
		$("#comics").tmpl(comics).appendTo("#main");		

	}
);



