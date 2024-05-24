
var apiLive = "/api/"


function Appointment() {
    
    $.ajax({
        type: 'GET',
        url: apiLive + 'BaranggayApi/getBgy',
        success: function (data) {
          $.each(data, function (index, value) {
            $("select[name=baranggayId]").append(
              '<option value="' + value.id + '">' + value.baranggayName + "</option>"
            );
          });
        },
    });

    $.ajax({
      type: 'GET',
      url: apiLive + 'ServicesApi/getServices',
      success: function (data) {
        $.each(data, function (index, value) {
          $("select[name=servicesId]").append(
            '<option value="' + value.id + '">' + value.service + "</option>"
          );
        });
      },
  });

    $.ajax({
      type: "GET",
      url: apiLive + "PetTypeApi/getPetTypes",
      success: function (data) {
          var html = '<option value="">Select Pet Type</option>';
          $.each(data, function (i, item) {
              html += '<option value="' + item.id + '">' + item.petTypeName + "</option>";
          });
          $("select[name=petTypeId]").html(html);
          // render divisionsId2 select
          $("select[name=petTypeId]").on("change", function () {
              var typeId = $("select[name=petTypeId]").val();
              $.ajax({
                  type: "GET",
                  url: apiLive + "BreedApi/getBreedbyType/" + typeId,
                  success: function (data) {
                      var html = '<option value="">Select Breed</option>';
                      $.each(data, function (i, item) {
                          html +=
                          '<option value="' + item.id + '">' + item.breedName  + "</option>";
                        });
                      $("select[name=breedTypeId]").html(html);
                  },
              });
          });
      },
  });


}