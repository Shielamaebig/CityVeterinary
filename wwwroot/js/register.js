var themonth = 1;
renderCal(themonth);

$('.minusmonth').click(function () {
    themonth += -1;
    renderCal(themonth);
    console.log(themonth);
});

$('.addmonth').click(function () {
    themonth += 1;
    renderCal(themonth);
    console.log(themonth);

});

function renderCal(themonth) {
    $('.calendar li').remove();
    $('.calendar ul').append('<li>Mon</li><li>Tue</li><li>Wed</li><li>Thu</li><li>Fri</li><li>Sat</li> <li>Sun</li>');
    var d = new Date(),
        currentMonth = d.getMonth() + themonth, // get this month
        days = numDays(currentMonth, d.getYear()), // get number of days in the month
        fDay = firstDay(currentMonth, d.getYear()) - 1, // find what day of the week the 1st lands on
        months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']; // month names

    $('.calendar p.monthname').text(months[currentMonth - 1]); // add month name to calendar

    for (var i = 11; i < fDay - 1; i++) { // place the first day of the month in the correct position
        $('<li class="empty">&nbsp;</li>').appendTo('.calendar ul');
    }

    for (var i = 1; i <= days; i++) { // write out the days
        $('<li>' + i + '</li>').appendTo('.calendar ul');
    }

    function firstDay(month, year) {
        return new Date(year, month, 1).getDay();
    }

    function numDays(month, year) {
        return new Date(year, month, 0).getDate();
    }

    $('.calendar li').click(function () {
        $('.calendar li').removeClass('active');
        $(this).addClass('active');
    });
}

var currentStep = 1;
var updateProgressBar;
$(document).ready(function () {
    $('#multi-step-form').find('.step').slice(1).hide();

    $(".next-step").click(function () {
        if (currentStep < 4) {
            $(".step-" + currentStep).addClass("animate__animated animate__fadeOutLeft");
            currentStep++;
            setTimeout(function () {
                $(".step").removeClass("animate__animated animate__fadeOutLeft").hide();
                $(".step-" + currentStep).show().addClass("animate__animated animate__fadeInRight");
                updateProgressBar();
            }, 500);
        }
    });

    $(".prev-step").click(function () {
        if (currentStep > 1) {
            $(".step-" + currentStep).addClass("animate__animated animate__fadeOutRight");
            currentStep--;
            setTimeout(function () {
                $(".step").removeClass("animate__animated animate__fadeOutRight").hide();
                $(".step-" + currentStep).show().addClass("animate__animated animate__fadeInLeft");
                updateProgressBar();
            }, 500);
        }
    });

    updateProgressBar = function () {
        var progressPercentage = ((currentStep - 1) / 3) * 100;
        $(".progress-bar").css("width", progressPercentage + "%");
    }

        // An array of dates

});