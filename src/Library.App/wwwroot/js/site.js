jQuery(function ($) {
    $("input[name='Input.PostalCode']").change(function () {
        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;
        $.get("https://ws.apicep.com/cep.json?", { code: cep_code }, function (result) {
            if (result.status == 200) {
                $("input[name='Input.PostalCode']").val(result.code);
                $("input[name='Input.District']").val(result.district);
                $("input[name='Input.City']").val(result.city);
                $("input[name='Input.UF']").val(result.state);
            }
            else if (result.status == 404) {
                $.get("https://cep.awesomeapi.com.br/json/" + cep_code, function (ret) {


                    $("input[name='Input.CEP']").val(ret.cep);
                    $("input[name='Input.District']").val(ret.district);
                    $("input[name='Input.City']").val(ret.city);
                    $("input[name='Input.UF']").val(ret.state);
                });
            }
        });
    });
});