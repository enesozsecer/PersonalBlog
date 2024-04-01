
var baslik = "";
$("#ekle").click(function (e) {
    $("#IdWork").val("");
    $("#PhotoWork").val("");
    $("#CompanyName").val("");
    $("#Title").val("");
    $("#Experience").val("");
    $("#Description").val("");
    $("#StartingDate").val("");
    $("#EndingDate").val("");

    var baslik = "İş Bilgisi Ekle";

    $("#staticBackdropLabel").text(baslik);

    $('#staticBackdropUpdate').modal("show");
});
function Update(Id, Photo, CompanyName, Title, Experience, Description, StartingDate, EndingDate) {
    $("#IdWork").val(Id);
    var fullImagePath = '/images/' + Photo;
    $("#Photo11").attr("src", fullImagePath);
    $("#PhotoWork").val(Photo);
    $("#CompanyName").val(CompanyName);
    $("#Title").val(Title);
    $("#Experience").val(Experience);
    $("#Description").val(Description);
    $("#StartingDate").val(StartingDate);
    $("#EndingDate").val(EndingDate);
    baslik = "Eğitim Bilgisi Güncelle";
    $("#staticBackdropLabel").text(baslik);
    $("#staticBackdropUpdate").modal("show");
}
$("#update").click(function (e) {
    e.preventDefault(); // Form submitini engelle

    var formValid = true; // Form geçerliliği kontrolü

    // Her form elemanını kontrol et
    $("form input[required], form textarea[required]").each(function () {
        // Eğer boşsa
        if (!$(this).val()) {
            formValid = false; // Form geçersiz
            $(this).addClass("is-invalid"); // Hata göstergesi ekle
            $(this).siblings(".invalid-feedback").remove(); // Var olan hata mesajını kaldır
            $(this).after('<div class="invalid-feedback">Bu alan boş bırakılamaz.</div>'); // Yeni hata mesajı ekle
        } else {
            $(this).removeClass("is-invalid"); // Hata göstergesini kaldır
            $(this).siblings(".invalid-feedback").remove(); // Hata mesajını kaldır
        }
    });

    // Eğer form geçerliyse
    if (formValid) {
        var formData = new FormData();

        // Form alanlarını FormData'ya ekle
        formData.append("Id", $("#IdWork").val());
        formData.append("Photo", $("#PhotoWork").val());
        formData.append("CompanyName", $("#CompanyName").val());
        formData.append("Title", $("#Title").val());
        formData.append("Experience", $("#Experience").val());
        formData.append("Description", $("#Description").val());
        formData.append("StartingDate", $("#StartingDate").val());
        formData.append("EndingDate", $("#EndingDate").val());
        var file = $("#FormFile")[0].files[0];
        formData.append("FormFile", file);

        $.ajax({
            type: "POST",
            url: "/CrudWork",
            data: formData,
            processData: false,  // processData ve contentType false olmalı
            contentType: false,
            success: function (response) {
                if (response.success) {
                    Swal.fire({
                        title: "Başarılı!",
                        text: response.responseText,
                        icon: "success"

                    }).then(function () {
                        location.reload();
                    });;
                    $("#staticBackdropUpdate").modal("hide");
                } else {
                    Swal.fire({
                        title: "HATA!!!",
                        text: response.responseText,
                        icon: "error"
                    });
                    $("#staticBackdropUpdate").modal("hide");
                }
            },
        });
    }
});
function confirmDelete(id) {
    // Swal onay iletişim kutusu gösterme
    Swal.fire({
        title: "Emin misiniz?",
        text: "Bu öğeyi silmek istediğinizden emin misiniz?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Evet, sil",
        cancelButtonText: "İptal"
    }).then((result) => {
        // Kullanıcı onaylarsa silme işlemini gerçekleştirme
        if (result.isConfirmed) {
            // AJAX kullanarak silme işlemini gerçekleştirme
            $.ajax({
                type: "POST",
                data: { id: id },
                url: "/DeleteWork",
                success: function (response) {
                    // Başarılı bir şekilde silindiyse
                    if (response.success) {
                        // Swal ile başarılı iletişim kutusu gösterme
                        Swal.fire({
                            title: "Başarılı!",
                            text: "Öğe başarıyla silindi.",
                            icon: "success"
                        }).then(function () {
                            // Sayfayı yenileme
                            location.reload();

                        });
                    } else {
                        // Swal ile hata iletişim kutusu gösterme
                        Swal.fire({
                            title: "Hata!",
                            text: response.message,
                            icon: "error"
                        });
                    }
                }
            });
        }
    });
}


