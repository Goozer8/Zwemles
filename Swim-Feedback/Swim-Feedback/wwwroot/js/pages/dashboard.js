var dashboard = {};

dashboard.init = function (stats) {
    const ctx = document.getElementById('score-chart');

    const config = {
        type: 'bar',
        data: {
            labels: [
                "0-10",
                "11-20",
                "21-30",
                "31-40",
                "41-50",
                "51-60",
                "61-70",
                "71-80",
                "81-90",
                "91-100",
            ],
            datasets: [
                {
                    label: 'Dataset 1',
                    data: stats,
                }
            ]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    display: false,
                },
                title: {
                    display: true,
                    text: 'Scores'
                }
            }
        },
    };


    dashboard.chart = new Chart(ctx, config);
};

dashboard.updateChart = function (stats) {
    dashboard.chart.data.datasets[0].data = stats;
    dashboard.chart.update();
};
