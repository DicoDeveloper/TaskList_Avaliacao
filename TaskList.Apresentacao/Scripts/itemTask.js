$(document).ready(function () {
    $('.progress').css('width', $('.panel').css('width'));

    $('[type="checkbox"]').on('click', function () {
        if ($(this).parent().parent().parent().css('display') !== 'none') {
            if ($(this)[0].checked) {
                $(this).parent().find('[data-status]').val('Concluido');
            }
            else {
                $(this).parent().find('[data-status]').val('Normal');
            }
        }

        $('#btn_confirmar').removeClass('scale-out');
        $('#btn_cancelar').removeClass('scale-out');
    });

    $('#btn_confirmar').on('click', function () {
        $.ajax({
            url: 'ItemTask/Salvar',
            type: 'post',
            data: $('form').serialize(),
            dataType: 'json',
            async: true,
            beforeSend: function () {
                $(".progress").show();
            }
        }).done(function (data) {
            if (data.Erro == '') {
                esconderBtns();
                $(".progress").hide();
            }
            else {
                $(".progress").hide();
                alert(data.Erro);
            }
        });
    });

    $('#btn_cancelar').on('click', function () {
        document.location.reload();
    });

    $('#task').keypress(function (e) {
        if (e.which === 13) {
            $('#btn_add').click();
        }
    });

    $('#task').on('blur', function () {
        var tasks = $('.task').find('span');
        for (var i = 0; i < tasks.length; i++) {
            if (tasks[i].innerHTML === $('#task').val() && tasks[i].parentElement.children[4].value !== 'Cancelado') {
                $('#task').parent().find('span').attr('data-error', 'Já existe uma task com essa descrição');
                $('#task').removeClass('valid');
                $('#task').addClass('invalid');
                return;
            }
        }

        if ($('#task').val() === '') {
            $('#task').parent().find('span').attr('data-error', 'Obrigatório');
            $('#task').removeClass('valid');
            $('#task').addClass('invalid');
        }
    });

    $('#btn_add').on('click', function () {
        var tasks = $('.task').find('span');
        for (var i = 0; i < tasks.length; i++) {
            if (tasks[i].innerHTML === $('#task').val() && tasks[i].parentElement.children[4].value !== 'Cancelado') {
                $('#task').parent().find('span').attr('data-error', 'Já existe uma task com essa descrição');
                $('#task').removeClass('valid');
                $('#task').addClass('invalid');
                return;
            }
        }

        if ($('#task').val() === '') {
            $('#task').parent().find('span').attr('data-error', 'Obrigatório');
            $('#task').removeClass('valid');
            $('#task').addClass('invalid');
        } else {
            $('#task_list').append($itemTask.replace(new RegExp(':indice', 'g'), $('[type="checkbox"]').length).replace(new RegExp(':titulo', 'g'), $('#task').val()));
            $('#task').val('');
            $('#task').removeClass('valid');
            $('#btn_confirmar').removeClass('scale-out');
            $('#btn_cancelar').removeClass('scale-out');

            $('[name="Task[' + $('[type="checkbox"]').length + '].Titulo"]').parent().find('.remove-task').on('click', function () {
                var task = $(this).parent().parent().parent();
                task.hide();
                task.find('[data-status]')[0].value = 'Cancelado';
            });

            $('.tooltipped').tooltip();
        }
    });

    $('.remove-task').on('click', function () {
        var task = $(this).parent().parent().parent();
        task.hide();
        task.find('[data-status]')[0].value = 'Cancelado';
    });

    $('.tooltipped').tooltip();

    $('form').submit(function (event) {
        event.preventDefault();
    });
});

function esconderBtns() {
    $('#btn_confirmar').addClass('scale-out');
    $('#btn_cancelar').addClass('scale-out');
}

$itemTask = '<div class="row task"><div class="col s12"><label><input type="checkbox" /><span>:titulo </span><a class="btn-floating btn-small waves-effect waves-light red tooltipped remove-task right" data-position="left" data-tooltip="Cancelar task"><i class="material-icons">remove</i></a><input data-status type="hidden" name="Task[:indice].Titulo" value=":titulo" /><input type="hidden" name="Task[:indice].Id" value="0" /><input data-status type="hidden" name="Task[:indice].Status" value="Normal" /></label></div></div>';