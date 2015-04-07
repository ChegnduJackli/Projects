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
		
		for(var i=0;i<comics.length;i++){
			$("#main").append('<div class="comic"><img src='
				+ comics[i].imgSrc +
				'<div class="details"><div class="title"><h3>'
				+ comics[i].title +
				'</h3></div><div class="year">'
				+ comics[i].year+
				'</div><div class="number">'
				+ comics[i].number+
				'</div></div></div>'
			);
		}
	$.template('comics' , '<div class="comic"><img src="${imgSrc}" /><div class="details"><div class="title"><h3>${title}</h3></div><div class="year">${year}</div><div class="number">${number}</div></div></div>');
	}
);



