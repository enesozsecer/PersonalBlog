
var baslik = "";
$("#ekle").click(function (e) {
    $("#Id20").val("");
    $("#Name20").val("");
    $("#Percentile").val("");
    
    var baslik = "Eğitim Bilgisi Ekle";

    $("#staticBackdropLabel").text(baslik);

    $('#staticBackdropUpdate').modal("show");
});
function Update(Id, Photo, Degree, SchoolName, Faculty, Section, Score, Description, StartingDate, EndingDate) {
    $("#Id20").val(Id);
    var fullImagePath = '/images/' + Photo;
    $("#Photo21").attr("src", fullImagePath);
    $("#Photo20").val(Photo);
    $("#Degree").val(Degree);
    $("#SchoolName").val(SchoolName);
    $("#Faculty").val(Faculty);
    $("#Section").val(Section);
    $("#Score").val(Score);
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
        formData.append("Id", $("#Id20").val());
        formData.append("Photo", $("#Photo20").val());
        formData.append("Degree", $("#Degree").val());
        formData.append("SchoolName", $("#SchoolName").val());
        formData.append("Faculty", $("#Faculty").val());
        formData.append("Section", $("#Section").val());
        formData.append("Score", $("#Score").val());
        formData.append("Description", $("#Description").val());
        formData.append("StartingDate", $("#StartingDate").val());
        formData.append("EndingDate", $("#EndingDate").val());
        var file = $("#FormFile")[0].files[0];
        formData.append("FormFile", file);

        $.ajax({
            type: "POST",
            url: "/CrudEducation",
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
                url: "/DeleteEducation",
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


