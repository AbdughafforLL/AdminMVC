function index() {

	// circle 1
	$('#circle1').circleProgress({
		value: 0.7,
		size: 60,
		fill: {
			color: ["#ff9b21"]
		}
	})
		.on('circle-animation-progress', function (event, progress) {
			$(this).find('strong').html(Math.round(70 * progress) + '<i>%</i>');
		});

	// circle 2
	$('#circle2').circleProgress({
		value: 0.85,
		size: 60,
		fill: {
			color: ["#19b159"]
		}
	})
		.on('circle-animation-progress', function (event, progress) {
			$(this).find('strong').html(Math.round(85 * progress) + '<i>%</i>');
		});

	// circle 3
	$('#circle3').circleProgress({
		value: 0.85,
		size: 60,
		fill: {
			color: ["#01b8ff"]
		}
	})
		.on('circle-animation-progress', function (event, progress) {
			$(this).find('strong').html(Math.round(90 * progress) + '<i>%</i>');
		});

}

/*Data Table */
/*
$('#recentorders').DataTable({
	"order": [[1, "asc"]],
	"language": {
		searchPlaceholder: 'Search...',
		sSearch: '',
	}
});
*/
//______Select2
$('.select2').select2({
	minimumResultsForSearch: Infinity
});
