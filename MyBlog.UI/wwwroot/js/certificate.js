
var baslik = "";
$("#ekle").click(function (e) {
    $("#IdCertificate").val("");
    $("#PhotoCertificate").val("");
    $("#CertificateName").val("");
    $("#CertificateCode").val("");
    $("#Corporation").val("");
    $("#DateOfIssue").val("");
    $("#Description").val("");

    var baslik = "Sertifika Bilgisi Ekle";

    $("#staticBackdropLabel").text(baslik);

    $('#staticBackdropUpdate').modal("show");
});
function Update(Id, Photo, CertificateName, CertificateCode, Corporation, DateOfIssue, Description) {
    $("#IdCertificate").val(Id);
    var fullImagePath = '/images/' + Photo;
    $("#Photo21").attr("src", fullImagePath);
    $("#PhotoCertificate").val(Photo);
    $("#CertificateName").val(CertificateName);
    $("#CertificateCode").val(CertificateCode);
    $("#Corporation").val(Corporation);
    $("#DateOfIssue").val(DateOfIssue);
    $("#Description").val(Description);
    baslik = "Sertifika Bilgisi Güncelle";
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
        formData.append("Id", $("#IdCertificate").val());
        formData.append("Photo", $("#PhotoCertificate").val());
        formData.append("CertificateName", $("#CertificateName").val());
        formData.append("CertificateCode", $("#CertificateCode").val());
        formData.append("Corporation", $("#Corporation").val());
        formData.append("DateOfIssue", $("#DateOfIssue").val());
        formData.append("Description", $("#Description").val());
        var file = $("#FormFile")[0].files[0];
        formData.append("FormFile", file);

        $.ajax({
            type: "POST",
            url: "/CrudCertificate",
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
                url: "/DeleteCertificate",
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


