function AddOrder(){
	$.ajax({
		type: "GET",
		url: 'MyOrders/AddOrder',
		success: function(data){
			$("#NewOrder").html(data);
		}
	});
}

function AddPart(){
//	var num = $('[name=tcol1]')
	$.ajax({
		type: "GET",
		url: 'MyOrders/AddPart',
		data: new {number = },
		success: function(data){
			$("#NewOrder").html(data);
		}
	});
}