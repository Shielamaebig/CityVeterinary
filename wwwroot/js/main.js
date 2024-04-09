// $(document).ready(function () {

//         //json token 
//         var data = localStorage.getItem('token');
//         var base64Url = data.split('.')[1];
//         var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
//         var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
//             return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
//         }).join(''));
//         var raw = JSON.parse(jsonPayload);
//         localStorage.setItem('role', raw.display_role);
//         localStorage.setItem('name', raw.display_name);
//     if (localStorage.getItem("token") === null) { 
//         window.location.href = "/Login";
//     }
//     else {
//         console.log(raw.display_name);
//     }

//     var logNames =  $("#logName").text("Welocome! " + (raw.display_name).split(' ').slice(0, 2).join(' '));

//     logout();
// });

function logout(){
    $('.logout').on('click', function(){
        localStorage.clear();
        if (localStorage.getItem("token") === null) { 
            window.location.href = "/Login";
        }
        else {
            console.log('not empty');
        }
    
    });
}


function encoderScripts() {
  var encoderTable = $('#cityVetEncoder').DataTable({
        ajax: { 
            url: 'api/EncoderApi/getEncoder', 
            dataSrc: "", 
        },
        autoWidth: false, 
        pagingType: "simple_numbers",
        columns: 
                [     
                    {
                        // display count
                        data: null,
                        className: 'text-center',
                        render: function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        },
                    },
                    { 
                        data: "dateAdded", 
                        className: 'text-center' 
                    }, 
                    { 
                        data: "encoderName", 
                        className: 'text-center'
                    },
                    {
                        data: null ,
                        className: 'text-center',
                        render: function(data, row) {
                            return (
                                '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
                                data.id +
                                '"><i class="bx bx-edit-alt"></i></button>'+
                                '  <button class="btn btn-danger btn-sm delete" data-id="' +
                                data.id +
                                '"><i class="bx bx-trash" ></i> </button>'
                            );
                        }
                    }
                ], 
                width: "240px",
    });
    // post
    $('#AddEncoderModal').on('click', '.btnEncoderPost', function () {
        var encoderName = $('input[name=encoderName]').val();
        var data = {
            encoderName: encoderName,
        }
        $.ajax({
            type: 'POST',
            url: 'api/EncoderApi/postEncoder',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (data) {
                new Noty({
                    theme : 'mint' , 
                    text: "Successfully Save!",
                    type: 'success',
                    layout : "topRight",
                    timeout : 1500,
                }).show();
                setTimeout(function() {
                    $('#AddEncoderModal').modal('hide');
                    encoderTable.ajax.reload();
                    $('#encoderForm').find('input[name=encoderName]').val(" ")
                }, 1300);

              
            }
        })
    });
 

    // update

    $('#cityVetEncoder').on('click', '.edit', function () {
        var id = $(this).attr("data-id");
        $.ajax({
            type: 'GET',
            url: 'api/EncoderApi/getEncoderbyId/' + id,
            success: function (data) {
                $('#updateModal').modal('show');
                $('#encoderupdate').find('input[name=id]').val(data.id);
                $('#encoderupdate').find('input[name=encoderName]').val(data.encoderName);
            }
        })
    });
    $('#updateModal').on('click', '.updateBtn', function () {
        var id = $("#encoderupdate").find('input[name=id]').val();
        var encoderName = $("#encoderupdate").find('input[name=encoderName]').val();
        var valdata = {
            id: id,
            encoderName: encoderName,
        }
        $.ajax({
            type:'PUT',
            url: '/api/EncoderApi/putEncoder/' + id,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(valdata),
            success: function (data) {
                console.log('ok');
                                new Noty({
                    theme : 'mint' , 
                    text: "Successfully Updated!",
                    type: 'info',
                    layout : "topRight",
                    timeout : 1500,
                }).show();
                setTimeout(function() {
                    $('#updateModal').modal('hide');
                    encoderTable.ajax.reload();
                }, 1300);
            }
        })
    });
    $('#cityVetEncoder').on('click', '.delete', function () {
        var id = $(this).attr("data-id");
        $.ajax({
            type: 'GET',
            url: 'api/EncoderApi/getEncoderbyId/' + id,
            success: function (data) {
                $('#deleteModal').modal('show');
                $('#encoderDelete').find('input[name=id]').val(data.id);
                $('#encoderDelete').find('input[name=encoderName]').val(data.encoderName);
                var Ename =  $('#encoderDelete').find('input[name=encoderName]').attr("value");

                console.log(JSON.stringify(Ename));
                $("#deleteName").text(Ename);
            }
        })
    });

    $('#deleteModal').on('click', '.deleteBtn', function () {
        var id = $("#encoderDelete").find('input[name=id]').val();
        var encoderName = $("#encoderDelete").find('input[name=encoderName]').val();

        var valdatas = {
            id: id,
            encoderName: encoderName
        }
        $.ajax({
            type: 'DELETE',
            url: 'api/EncoderApi/deleteEncoder/' + id,
            data: valdatas,
            success: function(data) {
                new Noty({
                    theme : 'mint' , 
                    text: "Successfully Delete field!",
                    type: "info",
                    layout : "topRight",
                    timeout : 1500,
                }).show();
                setTimeout(function() {
                    $('#deleteModal').modal('hide');
                    encoderTable.ajax.reload();
                }, 1300);
            },
            error: function(data) { 
            new Noty({
                theme : 'mint' , 
                text: "Something went wrong",
                type: 'info/information',
                layout : "topRight",
                timeout : 1500,
            }).show();
            setTimeout(function() {
                $('#deleteModal').modal('hide');
                encoderTable.ajax.reload();
            }, 1300);
            }
        })
    });
}
function baranggaysTable() {
    var bTable = $('#baranggayTable').DataTable({
        ajax: { 
            url: 'api/BaranggayApi/getBgy', 
            dataSrc: "", 
        },
        autoWidth: false, 
        pagingType: "simple_numbers",
        columns: 
                [     
                    {
                        // display count
                        data: null,
                        className: 'text-center',
                        render: function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        },
                    },
                    { 
                        data: "dateAdded", 
                        className: 'text-center' 
                    }, 
                    { 
                        data: "baranggayName", 
                        className: 'text-center'
                    },
                    {
                        data: null ,
                        className: 'text-center',
                        render: function(data, row) {
                            return (
                                '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
                                data.id +
                                '"><i class="bx bx-edit-alt"></i></button>'+
                                '  <button class="btn btn-danger btn-sm delete" data-id="' +
                                data.id +
                                '"><i class="bx bx-trash" ></i> </button>'
                            );
                        }
                    }
                ], 
                width: "240px",
    });

    $('#AddBgyModal').on('click', '.btnBgyPost', function () {
        console.log('clicked');

        var baranggayName = $('input[name=baranggayName]').val();
        var data = {
            baranggayName: baranggayName,
        }
        $.ajax({
            type: 'POST',
            url: 'api/BaranggayApi/postBaranggay',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (data) {
                new Noty({
                    theme : 'mint' , 
                    text: "Successfully Save!",
                    type: 'success',
                    layout : "topRight",
                    timeout : 1500,
                }).show();
                setTimeout(function() {
                    $('#AddBgyModal').modal('hide');
                    bTable.ajax.reload();
                    $('#bgyForm').find('input[name=baranggayName]').val(" ")
                }, 1300);

              
            }
        })
    });
 

    // update

    $('#baranggayTable').on('click', '.edit', function () {
        var id = $(this).attr("data-id");
        $.ajax({
            type: 'GET',
            url: 'api/BaranggayApi/getBgybyId/' + id,
            success: function (data) {
                $('#updateModal').modal('show');
                $('#bgyUpdate').find('input[name=id]').val(data.id);
                $('#bgyUpdate').find('input[name=baranggayName]').val(data.baranggayName);
            }
        })
    });
    $('#updateModal').on('click', '.updateBtn', function () {
        var id = $("#bgyUpdate").find('input[name=id]').val();
        var baranggayName = $("#bgyUpdate").find('input[name=baranggayName]').val();
        var valdata = {
            id: id,
            baranggayName: baranggayName,
        }
        $.ajax({
            type:'PUT',
            url: '/api/BaranggayApi/putBgy/' + id,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(valdata),
            success: function (data) {
                console.log('ok');
            new Noty({
                    theme : 'mint' , 
                    text: "Successfully Updated!",
                    type: 'info',
                    layout : "topRight",
                    timeout : 1500,
                }).show();
                setTimeout(function() {
                    $('#updateModal').modal('hide');
                    bTable.ajax.reload();
                }, 1300);
            }
        })
    });


    $('#baranggayTable').on('click', '.delete', function () {
        var id = $(this).attr("data-id");
        $.ajax({
            type: 'GET',
            url: 'api/BaranggayApi/getBgybyId/' + id,
            success: function (data) {
                $('#deleteModal').modal('show');
                $('#bgyDelete').find('input[name=id]').val(data.id);
                $('#bgyDelete').find('input[name=baranggayName]').val(data.baranggayName);
                var Ename =  $('#encoderDelete').find('input[name=baranggayName]').attr("value");

                console.log(JSON.stringify(Ename));
                $("#deleteName").text(Ename);
            }
        })
    });

    $('#deleteModal').on('click', '.deleteBtn', function () {
        var id = $("#bgyDelete").find('input[name=id]').val();
        var baranggayName = $("#bgyDelete").find('input[name=baranggayName]').val();

        var valdatas = {
            id: id,
            baranggayName: baranggayName
        }
        $.ajax({
            type: 'DELETE',
            url: 'api/BaranggayApi/deleteBgy/' + id,
            data: valdatas,
            success: function(data) {
                new Noty({
                    theme : 'mint' , 
                    text: "Successfully Delete field!",
                    type: "info",
                    layout : "topRight",
                    timeout : 1500,
                }).show();
                setTimeout(function() {
                    $('#deleteModal').modal('hide');
                    bTable.ajax.reload();
                }, 1300);
            },
            error: function(data) { 
            new Noty({
                theme : 'mint' , 
                text: "Something went wrong",
                type: 'info/information',
                layout : "topRight",
                timeout : 1500,
            }).show();
            setTimeout(function() {
                $('#deleteModal').modal('hide');
                bTable.ajax.reload();
            }, 1300);
            }
        })
    });
}