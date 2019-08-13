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
        var tasks = $('.task');
        for (var i = 0; i < tasks.length; i++) {
            if (tasks[i].children[0].children[0].children[1].innerText === $('#task').val() && tasks[i].children[0].children[5].value !== 'Cancelado') {
                $('#task').parent().find('span').attr('data-error', 'Já existe uma task com essa descrição');
                $('#task').removeClass('valid');
                $('#task').addClass('invalid');
                return;
            }
        }
    });

    $('#btn_add').on('click', function () {
        var tasks = $('.task');
        for (var i = 0; i < tasks.length; i++) {
            if (tasks[i].children[0].children[0].children[1].innerText === $('#task').val() && tasks[i].children[0].children[5].value !== 'Cancelado') {
                $('#task').parent().find('span').attr('data-error', 'Já existe uma task com essa descrição');
                $('#task').removeClass('valid');
                $('#task').addClass('invalid');
                return;
            }
        }

        if ($('#id_task').val() !== '') {
            var task = $('#task').val();
            $('#task').val('');
            $('#task').removeClass('valid');
            $('#btn_confirmar').removeClass('scale-out');
            $('#btn_cancelar').removeClass('scale-out');

            var id = $('#id_task').val();
            var ids = $('.id-task');
            for (var i = 0; i < ids.length; i++) {
                if (id === ids[i].value) {
                    ids[i].parentElement.children[3].value = task;
                    ids[i].parentElement.children[0].children[1].innerText = task;
                }
            }

            $('#id_task').val('');
        }
        else {
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

                $('[name="Task[' + ($('[type="checkbox"]').length - 1) + '].Titulo"]').parent().find('.remove-task').on('click', function () {
                    var task = $(this).parent();
                    task.hide();
                    task.find('[data-status]')[0].value = 'Cancelado';
                });

                $('[name="Task[' + ($('[type="checkbox"]').length - 1) + '].Titulo"]').parent().find('.editar-task').on('click', function () {
                    var task = $(this).parent();
                    $('#task').val(task.find('span')[0].innerHTML);
                    $('#id_task').val(task.find('input')[2].value);
                    M.updateTextFields();
                });

                $('.tooltipped').tooltip();
            }
        }
    });

    $('.remove-task').on('click', function () {
        var task = $(this).parent();
        task.hide();
        task.find('[data-status]')[0].value = 'Cancelado';
        $('#btn_confirmar').removeClass('scale-out');
        $('#btn_cancelar').removeClass('scale-out');
    });

    $('.editar-task').on('click', function () {
        var task = $(this).parent();
        $('#task').val(task.find('span')[0].innerHTML);
        $('#id_task').val(task.find('input')[2].value);
        M.updateTextFields();
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

$itemTask = '<div class="row task"><div class="col s12"><label><input type="checkbox" /><span>:titulo </span></label><a class="btn-floating btn-small waves-effect waves-light red tooltipped remove-task right" data-position="left" data-tooltip="Cancelar task"><i class="material-icons">remove</i></a><a class="btn-floating btn-small waves-effect waves-light cyan darken-1 tooltipped editar-task right" data-position="left" data-tooltip="Editar task"><i class="material-icons">edit</i></a><input data-status type="hidden" name="Task[:indice].Titulo" value=":titulo" /><input type="hidden" name="Task[:indice].Id" value="0" /><input data-status type="hidden" name="Task[:indice].Status" value="Normal" /></div></div>';