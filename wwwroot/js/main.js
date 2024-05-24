$(document).ready(function () {
  // $('a[data-toggle="tab"]').on("show.bs.tab", function (e) {
  //   localStorage.setItem("activeTab", $(e.target).attr("href"));
  // });
  // var activeTab = localStorage.getItem("activeTab");
  // if (activeTab) {
  //   $('#myTab a[href="' + activeTab + '"]').tab("show");
  // }
});

function encoderScripts() {
  var encoderTable = $("#cityVetEncoder").DataTable({
    ajax: {
      url: "api/EncoderApi/getEncoder",
      dataSrc: "",
    },
    autoWidth: false,
    pagingType: "simple_numbers",
    columns: [
      {
        // display count
        data: null,
        className: "text-center",
        render: function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1;
        },
      },
      {
        data: "dateAdded",
        className: "text-center",
      },
      {
        data: "encoderName",
        className: "text-center",
      },
      {
        data: null,
        className: "text-center",
        render: function (data, row) {
          return (
            '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
            data.id +
            '"><i class="bx bx-edit-alt"></i></button>' +
            '  <button class="btn btn-danger btn-sm delete" data-id="' +
            data.id +
            '"><i class="bx bx-trash" ></i> </button>'
          );
        },
      },
    ],
    width: "240px",
  });
  // post
  $("#AddEncoderModal").on("click", ".btnEncoderPost", function () {
    var encoderName = $("input[name=encoderName]").val();
    var data = {
      encoderName: encoderName,
    };
    $.ajax({
      type: "POST",
      url: "api/EncoderApi/postEncoder",
      contentType: "application/json",
      data: JSON.stringify(data),
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Save!",
          type: "success",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#AddEncoderModal").modal("hide");
          encoderTable.ajax.reload();
          $("#encoderForm").find("input[name=encoderName]").val(" ");
        }, 1300);
      },
    });
  });

  // update

  $("#cityVetEncoder").on("click", ".edit", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "api/EncoderApi/getEncoderbyId/" + id,
      success: function (data) {
        $("#updateModal").modal("show");
        $("#encoderupdate").find("input[name=id]").val(data.id);
        $("#encoderupdate")
          .find("input[name=encoderName]")
          .val(data.encoderName);
      },
    });
  });
  $("#updateModal").on("click", ".updateBtn", function () {
    var id = $("#encoderupdate").find("input[name=id]").val();
    var encoderName = $("#encoderupdate").find("input[name=encoderName]").val();
    var valdata = {
      id: id,
      encoderName: encoderName,
    };
    $.ajax({
      type: "PUT",
      url: "/api/EncoderApi/putEncoder/" + id,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify(valdata),
      success: function (data) {
        console.log("ok");
        new Noty({
          theme: "mint",
          text: "Successfully Updated!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#updateModal").modal("hide");
          encoderTable.ajax.reload();
        }, 1300);
      },
    });
  });
  $("#cityVetEncoder").on("click", ".delete", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "api/EncoderApi/getEncoderbyId/" + id,
      success: function (data) {
        $("#deleteModal").modal("show");
        $("#encoderDelete").find("input[name=id]").val(data.id);
        $("#encoderDelete")
          .find("input[name=encoderName]")
          .val(data.encoderName);
        var Ename = $("#encoderDelete")
          .find("input[name=encoderName]")
          .attr("value");

        console.log(JSON.stringify(Ename));
        $("#deleteName").text(Ename);
      },
    });
  });

  $("#deleteModal").on("click", ".deleteBtn", function () {
    var id = $("#encoderDelete").find("input[name=id]").val();
    var encoderName = $("#encoderDelete").find("input[name=encoderName]").val();

    var valdatas = {
      id: id,
      encoderName: encoderName,
    };
    $.ajax({
      type: "DELETE",
      url: "api/EncoderApi/deleteEncoder/" + id,
      data: valdatas,
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Delete field!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          encoderTable.ajax.reload();
        }, 1300);
      },
      error: function (data) {
        new Noty({
          theme: "mint",
          text: "Something went wrong",
          type: "info/information",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          encoderTable.ajax.reload();
        }, 1300);
      },
    });
  });
}
function baranggaysTable() {
  var bTable = $("#baranggayTable").DataTable({
    ajax: {
      url: "api/BaranggayApi/getBgy",
      dataSrc: "",
    },
    autoWidth: false,
    pagingType: "simple_numbers",
    columns: [
      {
        // display count
        data: null,
        className: "text-center",
        render: function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1;
        },
      },
      {
        data: "dateAdded",
        className: "text-center",
      },
      {
        data: "baranggayName",
        className: "text-center",
      },
      {
        data: null,
        className: "text-center",
        render: function (data, row) {
          return (
            '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
            data.id +
            '"><i class="bx bx-edit-alt"></i></button>' +
            '  <button class="btn btn-danger btn-sm delete" data-id="' +
            data.id +
            '"><i class="bx bx-trash" ></i> </button>'
          );
        },
      },
    ],
    width: "240px",
  });
}
function petTypesComponents() {
  var url = window.location.origin;
  var pTYpes = $("#petTypesTable").DataTable({
    ajax: {
      url: url + "/" + "api/PetTypeApi/getPetTypes",
      dataSrc: "",
    },
    autoWidth: false,
    columns: [
      {
        // display count
        data: null,
        className: "text-center",
        render: function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1;
        },
      },

      {
        data: "petTypeName",
        className: "text-center",
      },
      {
        data: null,
        className: "text-center",
        render: function (data, row) {
          return (
            '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
            data.id +
            '"><i class="bx bx-edit-alt"></i></button>' +
            '  <button class="btn btn-danger btn-sm delete" data-id="' +
            data.id +
            '"><i class="bx bx-trash" ></i> </button>'
          );
        },
      },
    ],
    width: "240px",
  });

  //poST
  $("#AddPetTypeModal").on("click", ".btnPetPost", function () {
    console.log("clicked");

    var petTypeName = $("input[name=petTypeName]").val();
    var data = {
      petTypeName: petTypeName,
    };
    $.ajax({
      type: "POST",
      url: "/api/PetTypeApi/postPetType",
      contentType: "application/json",
      data: JSON.stringify(data),
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Save!",
          type: "success",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#AddPetTypeModal").modal("hide");
          pTYpes.ajax.reload();
          $("#petTypeForm").find("input[name=petTypeName]").val(" ");
        }, 1300);
      },
    });
  });

  // GET BY iD

  $("#petTypesTable").on("click", ".edit", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/PetTypeApi/getPetbyId/" + id,
      success: function (data) {
        $("#updateTypeModal").modal("show");
        $("#petTypeUpdate").find("input[name=id]").val(data.id);
        $("#petTypeUpdate")
          .find("input[name=petTypeName]")
          .val(data.petTypeName);
      },
    });
  });
  // update BY iD

  $("#updateTypeModal").on("click", ".updateBtn", function () {
    var id = $("#petTypeUpdate").find("input[name=id]").val();
    var petTypeName = $("#petTypeUpdate").find("input[name=petTypeName]").val();
    var valdata = {
      id: id,
      petTypeName: petTypeName,
    };
    $.ajax({
      type: "PUT",
      url: "/api/PetTypeApi/putTypes/" + id,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify(valdata),
      success: function (data) {
        console.log("ok");
        new Noty({
          theme: "mint",
          text: "Successfully Updated!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#updateTypeModal").modal("hide");
          pTYpes.ajax.reload();
        }, 1300);
      },
    });
  });

  //GET BY ID FOR DELETE
  $("#petTypesTable").on("click", ".delete", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/PetTypeApi/getPetbyId/" + id,
      success: function (data) {
        $("#deleteModal").modal("show");
        $("#bgyDelete").find("input[name=id]").val(data.id);
        $("#bgyDelete").find("input[name=petTypeName]").val(data.petTypeName);
        var Ename = $("#bgyDelete")
          .find("input[name=petTypeName]")
          .attr("value");
        console.log(JSON.stringify(Ename));
        $("#deleteName").text(Ename);
      },
    });
  });

  //DELETE
  $("#deleteModal").on("click", ".deleteBtn", function () {
    var id = $("#bgyDelete").find("input[name=id]").val();
    var petTypeName = $("#bgyDelete").find("input[name=petTypeName]").val();

    var valdatas = {
      id: id,
      petTypeName: petTypeName,
    };
    $.ajax({
      type: "DELETE",
      url: "/api/PetTypeApi/deleteType/" + id,
      data: valdatas,
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Delete field!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          pTYpes.ajax.reload();
        }, 1300);
      },
      error: function (data) {
        new Noty({
          theme: "mint",
          text: "Something went wrong",
          type: "info/information",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          pTYpes.ajax.reload();
        }, 1300);
      },
    });
  });
}
function breedTypesComponents() {
  var url = window.location.origin;
  var breedTable = $("#breedTable").DataTable({
    ajax: {
      url: url + "/" + "api/BreedApi/getBreedName",
      dataSrc: "",
    },
    autoWidth: false,
    pagingType: "simple_numbers",
    columns: [
      {
        // display count
        data: null,
        className: "text-center",
        render: function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1;
        },
      },

      {
        data: "breedName",
        className: "text-center",
      },
      {
        data: "petTypeName",
        className: "text-center",
      },
      {
        data: null,
        className: "text-center",
        render: function (data, row) {
          return (
            '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
            data.id +
            '"><i class="bx bx-edit-alt"></i></button>' +
            '  <button class="btn btn-danger btn-sm delete" data-id="' +
            data.id +
            '"><i class="bx bx-trash" ></i> </button>'
          );
        },
      },
    ],
    width: "240px",
  });

  $.ajax({
    type: "GET",
    url: "/api/PetTypeApi/getPetTypes",
    success: function (data) {
      $.each(data, function (index, value) {
        $("select[name=petTypeId]").append(
          '<option value="' + value.id + '">' + value.petTypeName + "</option>"
        );
      });
    },
  });

  //poST
  $("#AddPBreedTypeModal").on("click", ".btnPetPost", function () {
    var petTypeId = $("select[name=petTypeId]").val();
    var breedName = $("input[name=breedName]").val();
    var data = {
      petTypeId: petTypeId,
      breedName: breedName,
    };

    $.ajax({
      type: "POST",
      url:
        "/api/BreedApi/PostBreed?dateAdded=date&petTypeId=" +
        petTypeId +
        "&breedName=" +
        breedName,
      contentType: "application/json",
      data: JSON.stringify(data),
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Save!",
          type: "success",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#AddPBreedTypeModal").modal("hide");
          breedTable.ajax.reload();
          $("#breedTypeForm").find("input[name=breedName]").val(" ");
          $("#breedTypeForm").find("select[name=petTypeId]").val(" ");
        }, 1300);
      },
    });
  });

  // GET BY iD

  $("#breedTable").on("click", ".edit", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/BreedApi/getBreedId/" + id,
      success: function (data) {
        $("#updateBreedModal").modal("show");
        $("#breedUpdate").find("input[name=id]").val(data.id);
        $("#breedUpdate").find("select[name=petTypeId]").val(data.petTypeId);
        $("#breedUpdate").find("input[name=breedName]").val(data.breedName);
      },
    });
  });
  // update BY iD

  $("#updateBreedModal").on("click", ".updateBtn", function () {
    var id = $("#breedUpdate").find("input[name=id]").val();
    var breedName = $("#breedUpdate").find("input[name=breedName]").val();
    var petTypeId = $("#breedUpdate").find("select[name=petTypeId]").val();
    var valdata = {
      id: id,
      petTypeId: petTypeId,
      breedName: breedName,
    };
    $.ajax({
      type: "PUT",
      url:
        "/api/BreedApi/putBreed/" +
        id +
        "?breedName=" +
        breedName +
        "&petTypeId=" +
        petTypeId,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify(valdata),
      success: function (data) {
        console.log("ok");
        new Noty({
          theme: "mint",
          text: "Successfully Updated!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#updateBreedModal").modal("hide");
          breedTable.ajax.reload();
        }, 1300);
      },
    });
  });

  //GET BY ID FOR DELETE
  $("#breedTable").on("click", ".delete", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/BreedApi/getBreedId/" + id,
      success: function (data) {
        $("#deleteModal").modal("show");
        $("#breedDelete").find("input[name=id]").val(data.id);
        $("#breedDelete").find("input[name=breedName]").val(data.breedName);
        $("#breedDelete").find("input[name=petTypeId]").val(data.petTypeId);

        var Ename = $("#breedDelete")
          .find("input[name=breedName]")
          .attr("value");
        console.log(JSON.stringify(Ename));
        $("#deleteName").text(Ename);
      },
    });
  });

  //DELETE
  $("#deleteModal").on("click", ".deleteBtn", function () {
    var id = $("#breedDelete").find("input[name=id]").val();
    var breedName = $("#breedDelete").find("input[name=breedName]").val();
    var petTypeId = $("#breedDelete").find("select[name=petTypeId]").val();

    var valdatas = {
      id: id,
      breedName: breedName,
      petTypeId: petTypeId,
    };
    $.ajax({
      type: "DELETE",
      url: "/api/BreedApi/deleteBreed/" + id,
      data: valdatas,
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Delete field!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          breedTable.ajax.reload();
        }, 1300);
      },
      error: function (data) {
        new Noty({
          theme: "mint",
          text: "Something went wrong",
          type: "info/information",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          breedTable.ajax.reload();
        }, 1300);
      },
    });
  });
}
function servicecTypeComponent() {
  var url = window.location.origin;
  var sTypes = $("#serviceTypeTable").DataTable({
    ajax: {
      url: url + "/" + "api/ServicesApi/getServices",
      dataSrc: "",
    },
    autoWidth: false,
    pagingType: "simple_numbers",
    columns: [
      {
        // display count
        data: null,
        className: "text-center",
        render: function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1;
        },
      },
      {
        data: "service",
        className: "text-center",
      },
      {
        data: null,
        className: "text-center",
        render: function (data, row) {
          return (
            '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
            data.id +
            '"><i class="bx bx-edit-alt"></i></button>' +
            '  <button class="btn btn-danger btn-sm delete" data-id="' +
            data.id +
            '"><i class="bx bx-trash" ></i> </button>'
          );
        },
      },
    ],
    width: "240px",
  });

  //poST
  $("#AddPServicespeModal").on("click", ".btnPost", function () {
    var service = $("input[name=service]").val();
    var data = {
      service: service,
    };
    $.ajax({
      type: "POST",
      url: "/api/ServicesApi/PostServices?dateAdded=a&service=" + service,
      contentType: "application/json",
      data: JSON.stringify(data),
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Save!",
          type: "success",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#AddPServicespeModal").modal("hide");
          sTypes.ajax.reload();
          $("#serviceForm").find("input[name=service]").val(" ");
        }, 1300);
      },
    });
  });

  // GET BY iD

  $("#serviceTypeTable").on("click", ".edit", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/ServicesApi/getServicebyId/" + id,
      success: function (data) {
        $("#updateServiceModal").modal("show");
        $("#serviceFormupdate").find("input[name=id]").val(data.id);
        $("#serviceFormupdate").find("input[name=service]").val(data.service);
      },
    });
  });
  // update BY iD

  $("#updateServiceModal").on("click", ".updateBtn", function () {
    var id = $("#serviceFormupdate").find("input[name=id]").val();
    var service = $("#serviceFormupdate").find("input[name=service]").val();
    var valdata = {
      id: id,
      service: service,
    };
    $.ajax({
      type: "PUT",
      url: "/api/ServicesApi/putServices/" + id + "?service=" + service,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify(valdata),
      success: function (data) {
        console.log("ok");
        new Noty({
          theme: "mint",
          text: "Successfully Updated!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#updateServiceModal").modal("hide");
          sTypes.ajax.reload();
        }, 1300);
      },
    });
  });

  //GET BY ID FOR DELETE
  $("#serviceTypeTable").on("click", ".delete", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/ServicesApi/getServicebyId/" + id,
      success: function (data) {
        $("#deleteModal").modal("show");
        $("#serviceDelete").find("input[name=id]").val(data.id);
        $("#serviceDelete").find("input[name=service]").val(data.service);
        var Ename = $("#serviceDelete")
          .find("input[name=service]")
          .attr("value");
        console.log(JSON.stringify(Ename));
        $("#deleteName").text(Ename);
      },
    });
  });

  //DELETE
  $("#deleteModal").on("click", ".deleteBtn", function () {
    var id = $("#serviceDelete").find("input[name=id]").val();
    var service = $("#serviceDelete").find("input[name=service]").val();
    var valdatas = {
      id: id,
      service: service,
    };
    $.ajax({
      type: "DELETE",
      url: "/api/ServicesApi/deleteService/" + id,
      data: valdatas,
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Delete field!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          sTypes.ajax.reload();
        }, 1300);
      },
      error: function (data) {
        new Noty({
          theme: "mint",
          text: "Something went wrong",
          type: "info/information",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          sTypes.ajax.reload();
        }, 1300);
      },
    });
  });
}

function VaccineTypeComponent() {
  var url = window.location.origin;
  var vaxTypes = $("#vaxTypeTable").DataTable({
    ajax: {
      url: url + "/" + "api/VaccineApi/GetVaccines",
      dataSrc: "",
    },
    autoWidth: false,
    pagingType: "simple_numbers",
    columns: [
      {
        // display count
        data: null,
        className: "text-center",
        render: function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1;
        },
      },
      {
        data: "dateAdded",
        className: "text-center",
      },
      {
        data: "manufacturer",
        className: "text-center",
      },
      {
        data: "lotNumber",
        className: "text-center",
      },
      {
        data: "vaccineName",
        className: "text-center",
      },
      {
        data: null,
        className: "text-center",
        render: function (data, row) {
          return (
            '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
            data.id +
            '"><i class="bx bx-edit-alt"></i></button>' +
            '  <button class="btn btn-danger btn-sm delete" data-id="' +
            data.id +
            '"><i class="bx bx-trash" ></i> </button>'
          );
        },
      },
    ],
    width: "240px",
  });

  //poST
  $("#AddVaccineeModal").on("click", ".btnPost", function () {
    var vaccineName = $("input[name=vaccineName]").val();
    var manufacturer = $("input[name=manufacturer]").val();
    var lotNumber = $("input[name=lotNumber]").val();

    var data = {
      vaccineName: vaccineName,
      manufacturer: manufacturer,
      lotNumber: lotNumber,
    };
    // "api/VaccineApi/PostVaccine?manufacturer=asd&lotNumber=asdasd&vaccineName=dasd",

    $.ajax({
      type: "POST",
      url:
        url +
        "/" +
        "api/VaccineApi/PostVaccine?manufacturer=" +
        manufacturer +
        "&lotNumber=" +
        lotNumber +
        "&vaccineName=" +
        vaccineName,
      contentType: "application/json",
      data: JSON.stringify(data),
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Save!",
          type: "success",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#AddVaccineeModal").modal("hide");
          vaxTypes.ajax.reload();
          $("#vaxForm").find("input[name=vaccineName]").val(" ");
          $("#vaxForm").find("input[name=manufacturer]").val(" ");
          $("#vaxForm").find("input[name=lotNumber]").val(" ");
        }, 1300);
      },
    });
  });

  // GET BY iD

  $("#vaxTypeTable").on("click", ".edit", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/VaccineApi/getByVaccineId/" + id,
      success: function (data) {
        $("#updateVaxModal").modal("show");
        $("#vaxFormupdate").find("input[name=id]").val(data.id);
        $("#vaxFormupdate")
          .find("input[name=manufacturer]")
          .val(data.manufacturer);
        $("#vaxFormupdate").find("input[name=lotNumber]").val(data.lotNumber);
        $("#vaxFormupdate")
          .find("input[name=vaccineName]")
          .val(data.vaccineName);
      },
    });
  });
  // update BY iD http://localhost:5287/api/VaccineApi/putVaccine/15?manufacturer=twe&lotNumber=wqw&vaccineName=sfw1

  $("#updateVaxModal").on("click", ".updateBtn", function () {
    var id = $("#vaxFormupdate").find("input[name=id]").val();
    var vaccineName = $("#vaxFormupdate").find("input[name=vaccineName]").val();
    var manufacturer = $("#vaxFormupdate")
      .find("input[name=manufacturer]")
      .val();
    var lotNumber = $("#vaxFormupdate").find("input[name=lotNumber]").val();

    var valdata = {
      id: id,
      vaccineName: vaccineName,
      manufacturer: manufacturer,
      lotNumber: lotNumber,
    };
    $.ajax({
      type: "PUT",
      url:
        "/api/VaccineApi/putVaccine/" +
        id +
        "?manufacturer=" +
        manufacturer +
        "&lotNumber=" +
        lotNumber +
        "&vaccineName=" +
        vaccineName,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify(valdata),
      success: function (data) {
        console.log("ok");
        new Noty({
          theme: "mint",
          text: "Successfully Updated!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#updateVaxModal").modal("hide");
          vaxTypes.ajax.reload();
        }, 1300);
      },
    });
  });

  //GET BY ID FOR DELETE
  $("#vaxTypeTable").on("click", ".delete", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/VaccineApi/getByVaccineId/" + id,
      success: function (data) {
        $("#deleteModal").modal("show");
        $("#vaxDelete").find("input[name=id]").val(data.id);
        $("#vaxDelete").find("input[name=vaccineName]").val(data.vaccineName);
        var Ename = $("#vaxDelete")
          .find("input[name=vaccineName]")
          .attr("value");
        console.log(JSON.stringify(Ename));
        $("#deleteName").text(Ename);
      },
    });
  });

  //DELETE
  $("#deleteModal").on("click", ".deleteBtn", function () {
    var id = $("#vaxDelete").find("input[name=id]").val();
    var vaccineName = $("#vaxDelete").find("input[name=vaccineName]").val();
    var valdatas = {
      id: id,
      vaccineName: vaccineName,
    };
    $.ajax({
      type: "DELETE",
      url: "/api/VaccineApi/deleteVax/" + id,
      data: valdatas,
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Delete field!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          vaxTypes.ajax.reload();
        }, 1300);
      },
      error: function (data) {
        new Noty({
          theme: "mint",
          text: "Something went wrong",
          type: "info/information",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          vaxTypes.ajax.reload();
        }, 1300);
      },
    });
  });
}
function vaccinatorFunction() {
  var url = window.location.origin;
  var vaxinatorTable = $("#vaxTorTable").DataTable({
    ajax: {
      url: url + "/" + "api/VaccinatorApi/getVaccinators",
      dataSrc: "",
    },
    autoWidth: false,
    pagingType: "simple_numbers",
    columns: [
      {
        // display count
        data: null,
        className: "text-center",
        render: function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1;
        },
      },
      {
        data: "dateAdded",
        className: "text-center",
      },

      {
        data: "fullName",
        className: "text-center",
      },
      {
        data: null,
        className: "text-center",
        render: function (data, row) {
          return (
            '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
            data.id +
            '"><i class="bx bx-edit-alt"></i></button>' +
            '  <button class="btn btn-danger btn-sm delete" data-id="' +
            data.id +
            '"><i class="bx bx-trash" ></i> </button>'
          );
        },
      },
    ],
    width: "240px",
  });

  // post
  $("#AddVacinatorModal").on("click", ".btnPost", function () {
    var fullName = $("input[name=fullName]").val();
    var data = {
      fullName: fullName,
    };
    $.ajax({
      type: "POST",
      url: "/api/VaccinatorApi/PostVaccinator?fullName=" + fullName,
      contentType: "application/json",
      data: JSON.stringify(data),
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Save!",
          type: "success",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#AddVacinatorModal").modal("hide");
          vaxinatorTable.ajax.reload();
          $("#vaxinatorForm").find("input[name=fullName]").val(" ");
        }, 1300);
      },
    });
  });

  //GET BY ID FOR Update
  $("#vaxTorTable").on("click", ".edit", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/VaccinatorApi/getbyIdVaxinator/" + id,
      success: function (data) {
        $("#updateVaxinatorModal").modal("show");
        $("#vaxinaTorupdate").find("input[name=id]").val(data.id);
        $("#vaxinaTorupdate").find("input[name=fullName]").val(data.fullName);
      },
    });
  });

  $("#updateVaxinatorModal").on("click", ".updateBtn", function () {
    var id = $("#vaxinaTorupdate").find("input[name=id]").val();
    var fullName = $("#vaxinaTorupdate").find("input[name=fullName]").val();
    var valdata = {
      id: id,
      fullName: fullName,
    };
    $.ajax({
      type: "PUT",
      url: "/api/VaccinatorApi/putVaccinator/" + id + "?fullName=" + fullName,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify(valdata),
      success: function (data) {
        console.log("ok");
        new Noty({
          theme: "mint",
          text: "Successfully Updated!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#updateVaxinatorModal").modal("hide");
          vaxinatorTable.ajax.reload();
        }, 1300);
      },
    });
  });

  //GET BY ID FOR DELETE
  $("#vaxTorTable").on("click", ".delete", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/VaccinatorApi/getbyIdVaxinator/" + id,
      success: function (data) {
        $("#deleteModal").modal("show");
        $("#vaxDelete").find("input[name=id]").val(data.id);
        $("#vaxDelete").find("input[name=fullName]").val(data.fullName);
        var Ename = $("#vaxDelete").find("input[name=fullName]").attr("value");
        console.log(JSON.stringify(Ename));
        $("#deleteName").text(Ename);
      },
    });
  });

  //DELETE
  $("#deleteModal").on("click", ".deleteBtn", function () {
    var id = $("#vaxDelete").find("input[name=id]").val();
    var fullName = $("#vaxDelete").find("input[name=fullName]").val();
    var valdatas = {
      id: id,
      fullName: fullName,
    };
    $.ajax({
      type: "DELETE",
      url: "/api/VaccinatorApi/deleteVaccinator/" + id,
      data: valdatas,
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Delete field!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          vaxinatorTable.ajax.reload();
        }, 1300);
      },
      error: function (data) {
        new Noty({
          theme: "mint",
          text: "Something went wrong",
          type: "info/information",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          vaxinatorTable.ajax.reload();
        }, 1300);
      },
    });
  });
}
function vetFunction() {
  var url = window.location.origin;
  var vetTable = $("#vetTable").DataTable({
    ajax: {
      url: url + "/" + "api/VeterinarianApi/getVeterinarians",
      dataSrc: "",
    },
    autoWidth: false,
    pagingType: "simple_numbers",
    columns: [
      {
        // display count
        data: null,
        className: "text-center",
        render: function (data, type, row, meta) {
          return meta.row + meta.settings._iDisplayStart + 1;
        },
      },
      {
        data: "dateAdded",
        className: "text-center",
      },

      {
        data: "vetName",
        className: "text-center",
      },
      {
        data: null,
        className: "text-center",
        render: function (data, row) {
          return (
            '<button class="btn btn-success btn-sm edit me-1 " data-id="' +
            data.id +
            '"><i class="bx bx-edit-alt"></i></button>' +
            '  <button class="btn btn-danger btn-sm delete" data-id="' +
            data.id +
            '"><i class="bx bx-trash" ></i> </button>'
          );
        },
      },
    ],
    width: "240px",
  });

  // post
  $("#AddVetModal").on("click", ".btnPost", function () {
    var vetName = $("input[name=vetName]").val();
    var data = {
      vetName: vetName,
    };
    $.ajax({
      type: "POST",
      url: "/api/VeterinarianApi/PostVets?vetName=" + vetName,
      contentType: "application/json",
      data: JSON.stringify(data),
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Save!",
          type: "success",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#AddVetModal").modal("hide");
          vetTable.ajax.reload();
          $("#vetForm").find("input[name=fullName]").val(" ");
        }, 1300);
      },
    });
  });

  //GET BY ID FOR Update
  $("#vetTable").on("click", ".edit", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/VeterinarianApi/getVetsbyId/" + id,
      success: function (data) {
        $("#updateVetModal").modal("show");
        $("#updatevetForm").find("input[name=id]").val(data.id);
        $("#updatevetForm").find("input[name=vetName]").val(data.vetName);
      },
    });
  });

  $("#updateVetModal").on("click", ".updateBtn", function () {
    var id = $("#updatevetForm").find("input[name=id]").val();
    var vetName = $("#updatevetForm").find("input[name=vetName]").val();
    var valdata = {
      id: id,
      vetName: vetName,
    };
    $.ajax({
      type: "PUT",
      url:
        "/api/VeterinarianApi/putVeterinarians/" + id + "?vetName=" + vetName,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      data: JSON.stringify(valdata),
      success: function (data) {
        console.log("ok");
        new Noty({
          theme: "mint",
          text: "Successfully Updated!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#updateVetModal").modal("hide");
          vetTable.ajax.reload();
        }, 1300);
      },
    });
  });

  //GET BY ID FOR DELETE
  $("#vetTable").on("click", ".delete", function () {
    var id = $(this).attr("data-id");
    $.ajax({
      type: "GET",
      url: "/api/VeterinarianApi/getVetsbyId/" + id,
      success: function (data) {
        $("#deleteModal").modal("show");
        $("#vetDelete").find("input[name=id]").val(data.id);
        $("#vetDelete").find("input[name=vetName]").val(data.vetName);
        var Ename = $("#vetDelete").find("input[name=vetName]").attr("value");
        console.log(JSON.stringify(Ename));
        $("#deleteName").text(Ename);
      },
    });
  });

  //DELETE
  $("#deleteModal").on("click", ".deleteBtn", function () {
    var id = $("#vetDelete").find("input[name=id]").val();
    var vetName = $("#vetDelete").find("input[name=vetName]").val();
    var valdatas = {
      id: id,
      vetName: vetName,
    };
    $.ajax({
      type: "DELETE",
      url: "/api/VeterinarianApi/deleteVet/" + id,
      data: valdatas,
      success: function (data) {
        new Noty({
          theme: "mint",
          text: "Successfully Delete field!",
          type: "info",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          vetTable.ajax.reload();
        }, 1300);
      },
      error: function (data) {
        new Noty({
          theme: "mint",
          text: "Something went wrong",
          type: "info/information",
          layout: "topRight",
          timeout: 1500,
        }).show();
        setTimeout(function () {
          $("#deleteModal").modal("hide");
          vetTable.ajax.reload();
        }, 1300);
      },
    });
  });
}
