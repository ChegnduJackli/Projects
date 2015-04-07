/* Author:

*/
$(document).ready( 
	function(){	
		var populate = function(data){
			console.log(data.d);
			$("#comics").tmpl(data.d).appendTo( "#main" );
		}
		$.ajax({
			type: 'get',
			url: 'data.json',
			success : populate,
			dataType: "json"
		  }
		)
	}
);



