$(function () {
	"use strict";

// chart 1
var options = {
    series: [{
        name: 'Sessions',
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
    }],
    chart: {
        type: 'line',
        height: 60,
        toolbar: {
            show: false
        },
        zoom: {
            enabled: false
        },
        dropShadow: {
            enabled: false,
            top: 3,
            left: 14,
            blur: 4,
            opacity: 0.12,
            color: '#8833ff',
        },
        sparkline: {
            enabled: true
        }
    },
    markers: {
        size: 0,
        colors: ["#8833ff"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7,
        }
    },
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '45%',
            endingShape: 'rounded'
        },
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 2.5,
        curve: 'smooth'
    },
    colors: ["#8833ff"],
    xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: 'dark',
        fixed: {
            enabled: false
        },
        x: {
            show: false
        },
        y: {
            title: {
                formatter: function (seriesName) {
                    return ''
                }
            }
        },
        marker: {
            show: false
        }
    }
};
var chart = new ApexCharts(document.querySelector("#chart1"), options);
chart.render();



// chart 2



// chart 3
var options = {
    series: [{
        name: 'Page Views',
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
    }],
    chart: {
        type: 'area',
        height: 60,
        toolbar: {
            show: false
        },
        zoom: {
            enabled: false
        },
        dropShadow: {
            enabled: false,
            top: 3,
            left: 14,
            blur: 4,
            opacity: 0.12,
            color: '#ffc107',
        },
        sparkline: {
            enabled: true
        }
    },
    markers: {
        size: 0,
        colors: ["#ffc107"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7,
        }
    },
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '45%',
            endingShape: 'rounded'
        },
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 2.5,
        curve: 'smooth'
    },
    colors: ["#ffc107"],
    xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: 'dark',
        fixed: {
            enabled: false
        },
        x: {
            show: false
        },
        y: {
            title: {
                formatter: function (seriesName) {
                    return ''
                }
            }
        },
        marker: {
            show: false
        }
    }
};
var chart = new ApexCharts(document.querySelector("#chart3"), options);
chart.render();



// chart 4
var options = {
    series: [{
        name: 'Bounce Rate',
        data: [400, 555, 257, 900, 613, 727, 414, 555, 257]
    }],
    chart: {
        type: 'bar',
        height: 60,
        toolbar: {
            show: false
        },
        zoom: {
            enabled: false
        },
        dropShadow: {
            enabled: false,
            top: 3,
            left: 14,
            blur: 4,
            opacity: 0.12,
            color: '#0dcaf0',
        },
        sparkline: {
            enabled: true
        }
    },
    markers: {
        size: 0,
        colors: ["#0dcaf0"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7,
        }
    },
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '40%',
            endingShape: 'rounded'
        },
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 2.4,
        curve: 'smooth'
    },
    colors: ["#0dcaf0"],
    xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: 'dark',
        fixed: {
            enabled: false
        },
        x: {
            show: false
        },
        y: {
            title: {
                formatter: function (seriesName) {
                    return ''
                }
            }
        },
        marker: {
            show: false
        }
    }
};
var chart = new ApexCharts(document.querySelector("#chart4"), options);
chart.render();




// chart 5
var options = {
    series: [{
        name: 'Avg. Session Duration',
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
    }],
    chart: {
        type: 'line',
        height: 60,
        toolbar: {
            show: false
        },
        zoom: {
            enabled: false
        },
        dropShadow: {
            enabled: false,
            top: 3,
            left: 14,
            blur: 4,
            opacity: 0.12,
            color: '#29cc39',
        },
        sparkline: {
            enabled: true
        }
    },
    markers: {
        size: 0,
        colors: ["#29cc39"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7,
        }
    },
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '45%',
            endingShape: 'rounded'
        },
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 2.5,
        curve: 'smooth'
    },
    colors: ["#29cc39"],
    xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: 'dark',
        fixed: {
            enabled: false
        },
        x: {
            show: false
        },
        y: {
            title: {
                formatter: function (seriesName) {
                    return ''
                }
            }
        },
        marker: {
            show: false
        }
    }
};
var chart = new ApexCharts(document.querySelector("#chart5"), options);
chart.render();




// chart 6
var options = {
    series: [{
        name: 'Sales',
        data: [4, 8, 6, 9, 6, 7, 4, 5, 2.5, 3]
    }],
    chart: {
        type: 'area',
        foreColor: '#9a9797',
        height: 250,
        toolbar: {
            show: false
        },
        zoom: {
            enabled: false
        },
        dropShadow: {
            enabled: false,
            top: 3,
            left: 14,
            blur: 4,
            opacity: 0.12,
            color: '#8833ff',
        },
        sparkline: {
            enabled: false
        }
    },
    markers: {
        size: 0,
        colors: ["#8833ff"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7,
        }
    },
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '45%',
            endingShape: 'rounded'
        },
    },
    
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 3,
        curve: 'smooth'
    },
    fill: {
        type: 'gradient',
        gradient: {
            shade: 'light',
            type: 'vertical',
            shadeIntensity: 0.5,
            gradientToColors: ['#fff'],
            inverseColors: false,
            opacityFrom: 0.8,
            opacityTo: 0.5,
            stops: [0, 100]
        }
    },
    colors: ["#8833ff"],
    grid: {
        show: true,
        borderColor: '#ededed',
        //strokeDashArray: 4,
    },
    yaxis: {
        labels: {
            formatter: function (value) {
                return value + "K";
            }
        },
    },
    xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
    },
    
    tooltip: {
        theme: 'dark',
        y: {
            formatter: function (val) {
                return "" + val + "K"
            }
        }
    }
};
var chart = new ApexCharts(document.querySelector("#chart6"), options);
chart.render();



// chart 7




// chart 8
var options = {
    series: [{
        name: 'Sessions',
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
    }],
    chart: {
        type: 'bar',
        height: 60,
        toolbar: {
            show: false
        },
        zoom: {
            enabled: false
        },
        dropShadow: {
            enabled: false,
            top: 3,
            left: 14,
            blur: 4,
            opacity: 0.12,
            color: '#8833ff',
        },
        sparkline: {
            enabled: true
        }
    },
    markers: {
        size: 0,
        colors: ["#8833ff"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7,
        }
    },
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '45%',
            endingShape: 'rounded'
        },
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 3,
       // curve: 'smooth'
    },
    colors: ["#8833ff"],
    xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: 'dark',
        fixed: {
            enabled: false
        },
        x: {
            show: false
        },
        y: {
            title: {
                formatter: function (seriesName) {
                    return ''
                }
            }
        },
        marker: {
            show: false
        }
    }
};
var chart = new ApexCharts(document.querySelector("#chart8"), options);
chart.render();



// chart 9
var options = {
    series: [{
        name: 'Sessions',
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
    }],
    chart: {
        type: 'area',
        height: 60,
        toolbar: {
            show: false
        },
        zoom: {
            enabled: false
        },
        dropShadow: {
            enabled: false,
            top: 3,
            left: 14,
            blur: 4,
            opacity: 0.12,
            color: '#f41127',
        },
        sparkline: {
            enabled: true
        }
    },
    markers: {
        size: 0,
        colors: ["#f41127"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7,
        }
    },
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '45%',
            endingShape: 'rounded'
        },
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 3,
       // curve: 'smooth'
    },
    colors: ["#f41127"],
    xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: 'dark',
        fixed: {
            enabled: false
        },
        x: {
            show: false
        },
        y: {
            title: {
                formatter: function (seriesName) {
                    return ''
                }
            }
        },
        marker: {
            show: false
        }
    }
};
var chart = new ApexCharts(document.querySelector("#chart9"), options);
chart.render();


// chart 10
var options = {
    series: [{
        name: 'Sessions',
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257]
    }],
    chart: {
        type: 'area',
        height: 60,
        toolbar: {
            show: false
        },
        zoom: {
            enabled: false
        },
        dropShadow: {
            enabled: false,
            top: 3,
            left: 14,
            blur: 4,
            opacity: 0.12,
            color: '#17a00e',
        },
        sparkline: {
            enabled: true
        }
    },
    markers: {
        size: 0,
        colors: ["#17a00e"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7,
        }
    },
    plotOptions: {
        bar: {
            horizontal: false,
            columnWidth: '45%',
            endingShape: 'rounded'
        },
    },
    dataLabels: {
        enabled: false
    },
    stroke: {
        show: true,
        width: 3,
       // curve: 'smooth'
    },
    colors: ["#17a00e"],
    xaxis: {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    },
    fill: {
        opacity: 1
    },
    tooltip: {
        theme: 'dark',
        fixed: {
            enabled: false
        },
        x: {
            show: false
        },
        y: {
            title: {
                formatter: function (seriesName) {
                    return ''
                }
            }
        },
        marker: {
            show: false
        }
    }
};
var chart = new ApexCharts(document.querySelector("#chart10"), options);
chart.render();



// chart 11
var options = {
    chart: {
        height: 330,
        type: 'radialBar',
        toolbar: {
            show: false
        }
    },
    plotOptions: {
        radialBar: {
            startAngle: -130,
            endAngle: 130,
            hollow: {
                margin: 0,
                size: '78%',
                //background: '#fff',
                image: undefined,
                imageOffsetX: 0,
                imageOffsetY: 0,
                position: 'front',
                dropShadow: {
                    enabled: false,
                    top: 3,
                    left: 0,
                    blur: 4,
                    color: '#dbb772',
                    opacity: 0.65
                }
            },
            track: {
                background: '#e1d8ca',
                //strokeWidth: '67%',
                margin: 0, // margin is in pixels
                dropShadow: {
                    enabled: false,
                    top: -3,
                    left: 0,
                    blur: 4,
                    color: '#8d6823',
                    opacity: 0.65
                }
            },
            dataLabels: {
                showOn: 'always',
                name: {
                    offsetY: -25,
                    show: true,
                    color: '#6c757d',
                    fontSize: '16px'
                },
                value: {
                    formatter: function (val) {
                        return val + "%";
                    },
                    color: '#000',
                    fontSize: '45px',
                    show: true,
                    offsetY: 10,
                }
            }
        }
    },
    fill: {
        type: 'gradient',
        gradient: {
            shade: 'dark',
            type: 'horizontal',
            shadeIntensity: 0.5,
            gradientToColors: ['#ad8233'],
            inverseColors: false,
            opacityFrom: 1,
            opacityTo: 1,
            stops: [0, 100]
        }
    },
    colors: ["#c5a05d"],
    series: [84],
    stroke: {
        lineCap: 'round',
        //dashArray: 4
    },
    labels: ['Overall Percentage'],
}
var chart = new ApexCharts(document.querySelector("#chart11"), options);
chart.render();



// chart 12
	



// chart 13
	// Create the chart
	


// chart 14
	// Create the chart
	Highcharts.chart('chart14', {
		chart: {
			height: 360,
			type: 'column',
			styledMode: true
		},
		credits: {
			enabled: false
		},
		title: {
			text: 'Visitor Age Group Status'
		},
		accessibility: {
			announceNewData: {
				enabled: true
			}
		},
		xAxis: {
			type: 'category'
		},
		yAxis: {
			title: {
				text: 'Age Group Status'
			}
		},
		legend: {
			enabled: false
		},
		plotOptions: {
			series: {
				borderWidth: 0,
				dataLabels: {
					enabled: true,
					format: '{point.y:.1f}K'
				}
			}
		},
		tooltip: {
			headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
			pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}%</b> of total<br/>'
		},
		series: [{
			name: "Age Group",
			colorByPoint: true,
			data: [{
				name: "18-24",
				y: 35.74,
				//drilldown: "Organic Search"
			}, {
				name: "25-34",
				y: 65.57,
				//drilldown: "Direct"
			}, {
				name: "35-44",
				y: 30.23,
				//drilldown: "Referral"
			}, {
				name: "45-54",
				y: 20.58,
				//drilldown: "Others"
			}, {
				name: "55-64",
				y: 15.58,
				//drilldown: "Others"
			}, {
				name: "65-80",
				y: 8.58,
				//drilldown: "Others"
			}]
		}],
		
	});

  //chart Main

    //var options = {
    //    series: [{
    //        name: 'Sales',
    //        data: [4, 8, 6, 9, 6, 7, 4, 5, 2.5, 3]
    //    }],
    //    chart: {
    //        type: 'area',
    //        foreColor: '#9a9797',
    //        height: 250,
    //        toolbar: {
    //            show: false
    //        },
    //        zoom: {
    //            enabled: false
    //        },
    //        dropShadow: {
    //            enabled: false,
    //            top: 3,
    //            left: 14,
    //            blur: 4,
    //            opacity: 0.12,
    //            color: '#8833ff',
    //        },
    //        sparkline: {
    //            enabled: false
    //        }
    //    },
    //    markers: {
    //        size: 0,
    //        colors: ["#8833ff"],
    //        strokeColors: "#fff",
    //        strokeWidth: 2,
    //        hover: {
    //            size: 7,
    //        }
    //    },
    //    plotOptions: {
    //        bar: {
    //            horizontal: false,
    //            columnWidth: '45%',
    //            endingShape: 'rounded'
    //        },
    //    },

    //    dataLabels: {
    //        enabled: false
    //    },
    //    stroke: {
    //        show: true,
    //        width: 3,
    //        curve: 'smooth'
    //    },
    //    fill: {
    //        type: 'gradient',
    //        gradient: {
    //            shade: 'light',
    //            type: 'vertical',
    //            shadeIntensity: 0.5,
    //            gradientToColors: ['#fff'],
    //            inverseColors: false,
    //            opacityFrom: 0.8,
    //            opacityTo: 0.5,
    //            stops: [0, 100]
    //        }
    //    },
    //    colors: ["#8833ff"],
    //    grid: {
    //        show: true,
    //        borderColor: '#ededed',
    //        //strokeDashArray: 4,
    //    },
    //    yaxis: {
    //        labels: {
    //            formatter: function (value) {
    //                return value + "K";
    //            }
    //        },
    //    },
    //    xaxis: {
    //        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
    //    },

    //    tooltip: {
    //        theme: 'dark',
    //        y: {
    //            formatter: function (val) {
    //                return "" + val + "K"
    //            }
    //        }
    //    }
    //};
    //var chart = new ApexCharts(document.querySelector("#chart336"), options);
    //chart.render();


 // world map
	
 jQuery('#geographic-map').vectorMap({
    map: 'world_mill_en',
    backgroundColor: 'transparent',
    borderColor: '#818181',
    borderOpacity: 0.25,
    borderWidth: 1,
    zoomOnScroll: false,
    color: '#009efb',
    regionStyle: {
        initial: {
            fill: '#6c757d'
        }
    },
    markerStyle: {
        initial: {
            r: 9,
            'fill': '#fff',
            'fill-opacity': 1,
            'stroke': '#000',
            'stroke-width': 5,
            'stroke-opacity': 0.4
        },
    },
    enableZoom: true,
    hoverColor: '#009efb',
    markers: [{
        latLng: [21.00, 78.00],
        name: 'I Love My India'
    }],
    series: {
        regions: [{
            values: {
                IN: '#29cc39',
                US: '#8833ff',
                CN: '#f41127',
                CA: '#e91e63',
                AU: '#ffd200'
            }
        }]
    },
    hoverOpacity: null,
    normalizeFunction: 'linear',
    scaleColors: ['#b6d6ff', '#005ace'],
    selectedColor: '#c9dfaf',
    selectedRegions: [],
    showTooltip: true,
    onRegionClick: function (element, code, region) {
        var message = 'You clicked "' + region + '" which has the code: ' + code.toUpperCase();
        alert(message);
    }
});




    Highcharts.chart('chart51', {
        chart: {
            type: 'area',
            height: 420,
            styledMode: true
        },
        credits: {
            enabled: false
        },
        accessibility: {
            //description: 'Image description: An area chart compares the nuclear stockpiles of the USA and the USSR/Russia between 1945 and 2017. The number of nuclear weapons is plotted on the Y-axis and the years on the X-axis. The chart is interactive, and the year-on-year stockpile levels can be traced for each country. The US has a stockpile of 6 nuclear weapons at the dawn of the nuclear age in 1945. This number has gradually increased to 369 by 1950 when the USSR enters the arms race with 6 weapons. At this point, the US starts to rapidly build its stockpile culminating in 32,040 warheads by 1966 compared to the USSR’s 7,089. From this peak in 1966, the US stockpile gradually decreases as the USSR’s stockpile expands. By 1978 the USSR has closed the nuclear gap at 25,393. The USSR stockpile continues to grow until it reaches a peak of 45,000 in 1986 compared to the US arsenal of 24,401. From 1986, the nuclear stockpiles of both countries start to fall. By 2000, the numbers have fallen to 10,577 and 21,000 for the US and Russia, respectively. The decreases continue until 2017 at which point the US holds 4,018 weapons compared to Russia’s 4,500.'
        },
        title: {
            text: 'Sales and Traffic Annual Report'
        },

        xAxis: {
            allowDecimals: false,
            type: 'datetime',
            labels: {
                formatter: function () {
                    return this.value; // clean, unformatted number for year
                }
            },
            accessibility: {
                //rangeDescription: 'Range: 1940 to 2017.'
            }
        },
        yAxis: {
            title: {
                text: ''
            },
            labels: {
                formatter: function () {
                    return this.value / 1000 + 'k';
                }
            }
        },
        tooltip: {
            pointFormat: '{series.name} had stockpiled <b>{point.y:,.0f}</b><br/>warheads in {point.x}'
        },
        plotOptions: {
            area: {
                pointStart: 1940,
                marker: {
                    enabled: false,
                    symbol: 'circle',
                    radius: 2,
                    states: {
                        hover: {
                            enabled: true
                        }
                    }
                }
            }
        },
        series: [{
            name: 'Sales',
            data: [
                null, null, null, null, null, 6, 11, 32, 110, 235,
                369, 640, 1005, 1436, 2063, 3057, 4618, 6444, 9822, 15468,
                20434, 24126, 27387, 29459, 31056, 31982, 32040, 31233, 29224, 27342,
                26662, 26956, 27912, 28999, 28965, 27826, 25579, 25722, 24826, 24605,
                24304, 23464, 23708, 24099, 24357, 24237, 24401, 24344, 23586, 22380,
                21004, 17287, 14747, 13076, 12555, 12144, 11009, 10950, 10871, 10824,
                10577, 10527, 10475, 10421, 10358, 10295, 10104, 9914, 9620, 9326,
                5113, 5113, 4954, 4804, 4761, 4717, 4368, 4018
            ]
        }, {
            name: 'Traffic',
            data: [null, null, null, null, null, null, null, null, null, null,
                5, 25, 50, 120, 150, 200, 426, 660, 869, 1060,
                1605, 2471, 3322, 4238, 5221, 6129, 7089, 8339, 9399, 10538,
                11643, 13092, 14478, 15915, 17385, 19055, 21205, 23044, 25393, 27935,
                30062, 32049, 33952, 35804, 37431, 39197, 45000, 43000, 41000, 39000,
                37000, 35000, 33000, 31000, 29000, 27000, 25000, 24000, 23000, 22000,
                21000, 20000, 19000, 18000, 18000, 17000, 16000, 15537, 14162, 12787,
                12600, 11400, 5500, 4512, 4502, 4502, 4500, 4500
            ]
        }]
    });


});