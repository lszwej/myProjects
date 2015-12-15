$(document).ready(function (){

    const SUN = 1.989E30;
    const GRAV = 6.67438E-11;
    const AUTOMETER = 149597870700;
    const YEARINSEC = 31536000;

    var masses = [3.30E23, 4.87E24, 5.97E24, 6.42E23, 1.90E27, 5.68E26, 8.68E25, 1.02E26, 1.27E22];
    var radiuses = [2440, 6052, 6378, 3397, 71492, 60268, 25559, 24766, 1150];
    var orbits = [0.39, 0.72, 1.0, 1.52, 5.2, 9.53, 19.19, 30.06, 39.52];

    function Calculator(mass, radius, orbit)
    {
        var massPlanet = mass;
        var radiusPlanet = radius*1000;
        var orbit = orbit;
        var first = 0;
        var orbitVel = 0;
        var sunMulGrav = GRAV*SUN;
        var auToMeter = orbit*AUTOMETER;

        this.firstVel = function()
        {
            first = Math.sqrt((massPlanet*GRAV)/radiusPlanet)/1000;
            if (first === Number.POSITIVE_INFINITY)
            {
                alert("Wartość pierwszej prędkości kosmicznej jest zbyt duża, aby ją obliczyć!");
                return 0.0;
            }
            return first.toPrecision(6);
        }

        this.secondVel = function()
        {
            var second = first*Math.sqrt(2);
            if (second === Number.POSITIVE_INFINITY)
            {
                alert("Wartość drugiej prędkości kosmicznej jest zbyt duża, aby ją obliczyć!");
                return 0.0;
            }
            return second.toPrecision(6);
        }

        this.orbitSpeed = function()
        {
            orbitVel = (Math.sqrt(sunMulGrav/auToMeter))/1000;
            if (orbitVel === Number.POSITIVE_INFINITY)
            {
                alert("Wartość prędkości orbitalnej jest zbyt duża, aby ją obliczyć!");
                return 0.0;
            }
            return orbitVel.toPrecision(6);
        }

        this.orbitPeriod = function()
        {
            var orbitYear = (2*Math.PI*Math.sqrt((Math.pow(auToMeter,3))/sunMulGrav))/YEARINSEC;
            if (orbitYear === Number.POSITIVE_INFINITY)
            {
                alert("Wartość okresu orbitalnego jest zbyt duża, aby ją obliczyć!");
                return 0.0;
            }
            return orbitYear.toPrecision(6);
        }

        this.thirdVel = function()
        {
            var third = orbitVel*Math.sqrt(2);
            if (third === Number.POSITIVE_INFINITY)
            {
                alert("Wartość trzeciej prędkości kosmicznej jest zbyt duża, aby ją obliczyć!");
                return 0.0;
            }
            return third.toPrecision(6);
        }
    }

    $("input:text").val("");
    $("#slonceMasa").val(SUN);
    $("#grawitacja").val(GRAV);

    $("select").change(function() {

        var index = $("select option:selected").index();
        var planet = $("select option:selected").val();
        if (index > 0)
        {
            --index;
            $("#masa").val(masses[index]);
            $("#promien").val(radiuses[index]);
            $("#orbita").val(orbits[index]);
        }
        else
            $("input:text[readonly!='readonly']").val("");
        $("img").attr("src", "./images/" + planet + ".jpg");
    });

    $("#calculate").click(function (){

        var mass = parseFloat($("#masa").val());
        var radius = parseFloat($("#promien").val());
        var orbit = parseFloat($("#orbita").val());

        if (isNaN(mass) || isNaN(radius) || isNaN(orbit))
            alert("Wpisane wartości nie są liczbami!");
        else if (mass <= 0 || radius <= 0 || orbit <= 0)
            alert("Wpisane wartości muszą być większe od zera!");
        else
        {
            var calc = new Calculator(mass, radius, orbit);
            var first = calc.firstVel();
            var second = calc.secondVel();
            var orbitVel = calc.orbitSpeed();
            var orbitPeriod = calc.orbitPeriod();
            var third = calc.thirdVel();

            $("#v1").val(first);
            $("#v2").val(second);
            $("#vc").val(orbitVel);
            $("#vt").val(orbitPeriod);
            $("#v3").val(third);
        }
    });
});
