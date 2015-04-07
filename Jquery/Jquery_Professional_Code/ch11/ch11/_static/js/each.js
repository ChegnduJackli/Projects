/* Author:

*/
$(document).ready( 
	function(){
		var comics = [
			{ 
				imgSrc : "cover1.jpg",
				title : "Captain Templates",
				themes : [ "code reuse" , "separation of content and behavior" , "template tags" ],
				year : "2010",
				number : "1"
			},			  
			{ 
				imgSrc : "cover2.jpg",
				title : "Captain Templates",
				themes : [ "code reuse" , "moustaches" , "templating for fun and profit" ],
				year : "2011",
				number : "2"
			},			  
			{ 
				imgSrc : "cover3.jpg",
				title : "Captain Templates",
				themes : [ "threes" ],
				year : "2012",
				number : "3"
			}	  			  
		]
		$("#comics").tmpl(comics).appendTo("#main");	
		$("#comics2").tmpl(comics).appendTo("#main");		

	}
);



