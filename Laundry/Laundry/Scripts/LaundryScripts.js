function AddOrder() {
    $.ajax({
        type: "GET",
        url: 'MyOrders/AddOrder',
        success: function (data) {
            $("#NewOrder").html(data);
            location.replace("/MyOrders#NewOrder");
        }
    });
}

function AddPart(){
	var orderId = $("#orderId").val();
	var priceId = $('select[name=prices]').val();
	var number = $('input[name=number]').val();
	$.ajax({
		type: "POST",
		url: 'MyOrders/AddOrderPart',
		data: JSON.stringify({ orderId: orderId, priceId: priceId, number: number }),
		dataType: 'json',
		contentType: 'application/json; charset=utf-8',
		success: function(data){
			$("#parts").append("dodano");
		}
	});
}

function Modify(id){
	var button = $("#button_"+id);
	if($(button).attr('state') == 0)
	{
		$(button).attr('state', 1);
		$(button).html("Zatwierdź");
		var row = $("#"+id+">td.value");
		row.html("<input id="+id+"/>");
	}
	else{
		var price = $("#"+id+">td.value>input").val();
		$.ajax({
		type: "POST",
		url: 'Pricing/Modify',
		data: JSON.stringify({priceId: id, price: price}),
		dataType: 'json',
		contentType: 'application/json; charset=utf-8',
		success: function(data){
			var row = $("#"+id+">td.value");
			$(button).attr('state', 0);
			$(button).html("Modyfikuj");
			row.html(price);
		}
	});
	}

}

function Accept(id){
	
}