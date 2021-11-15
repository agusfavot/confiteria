$("#artXVen").on("click", function () {
	$('#table2').hide()
	$('#table1').DataTable({
	})
});

$("#venXMoz").on("click", function () {
	$('#table1').hide();
	$('#table2').DataTable({
	})
});

$("#artMasVen").click(function () {
    alert("Activado articulo mas vendido");
})