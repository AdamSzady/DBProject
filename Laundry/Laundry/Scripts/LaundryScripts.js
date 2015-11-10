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
	var orderId = $("#orderId").val();
	var serviceId = $('select[name=service]').val();
	var thingId = $('select[name=thing]').val();
	var number = $('input[name=number]').val();
	$.ajax({
		type: "POST",
		url: 'MyOrders/AddOrderPart',
		data: JSON.stringify({orderId: orderId, serviceId: serviceId, thingId: thingId, number: number}),
		dataType: 'json',
		contentType: 'application/json; charset=utf-8',
		success: function(data){
			$("#parts").append("dodano");
		}
	});
}