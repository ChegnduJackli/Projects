
/*
 * Your application namespace
 */
var MyApp = {
/*
 * In it you have a common object which holds code common to all pages
 */
   common :
/*
 * In it, there’s a function that runs on $(document).ready() called init
 */
       init : function(){
/*
 * It initializes all the templates for your site
 */

	MyApp.common.templates();

/*
 * And then they're ready to be applied 
 */
          var comics = [
			{ 
				imgSrc : "cover1.jpg",
				title : "Captain Templates",
				year : "2010",
				number : "1",
				author : "Rob Larsen",
				authorBio : "Rob really likes JavaScript"
			},			  
			{ 
				imgSrc : "cover2.jpg",
				title : "Captain Templates",
				year : "2011",
				number : "2",
				author : "Bizarro Rob",
				authorBio : "Rob hates JavaScript"
			},			  
			{ 
				imgSrc : "cover3.jpg",
				title : "Captain Templates",
				year : "2012",
				number : "3"
				author : "rl",
				authorBio : "Rob minifies JavaScript"
			}	  			  
		];
		$.tmpl( "comics", comics ).appendTo( "#main" );	
       },
       templates: function(){
    			$.template('comics' , '<div class="comic"><img src="${imgSrc}" /><div class="details"><div class="title"><h3>${title}</h3></div><div class="year">${year}</div><div class="number">${number}</div></div></div>');
				$.template('author' , '<div class="author"><div class="name"><h3>${author}</h3></div><div class="bio"><p>${authorBio}</p></div></div>');
    		},
	}
}




