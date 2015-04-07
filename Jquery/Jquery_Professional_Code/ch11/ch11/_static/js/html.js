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
				number : "1",
				description : "<p>In this thrilling origin issue Captain Templates saves the day by using templates instead of a bunch of <strong>awkward</strong> string conceatnation</p>"
			},			  
			{ 
				imgSrc : "cover2.jpg",
				title : "Captain Templates",
				themes : [ "code reuse" , "moustaches" , "templating for fun and profit" ],
				year : "2011",
				number : "2",
				description : "<p>In battling his <em>arch nemesis</em> <strong>Doctor Plus Sign</strong> Captain Templates falls into a coma. </p><p>A thrilling issue with a cliffhanger ending</p>"
			},			  
			{ 
				imgSrc : "cover3.jpg",
				title : "Captain Templates",
				themes : [ "threes" ],
				year : "2012",
				number : "3",
				description : "<p>Captain Templates awakens from his coma and defeats the evil <strong>Doctor Plus Sign</strong></p>"
			}	  			  
		]
		$("#comics").tmpl(comics).appendTo("#main");			

	}
);



