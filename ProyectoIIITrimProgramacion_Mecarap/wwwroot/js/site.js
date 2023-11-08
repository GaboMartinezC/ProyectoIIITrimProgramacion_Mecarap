const Eliminar = (id, controlador) => {
    $.ajax({
        url: `/${controlador}/Eliminar`,
        type: "POST",
        data: { id: id },
        success: function (respuesta) {
            swal("Exito!", "Eliminado correctamente", "success");
        },
        error: function () {
            swal("Ha ocurrido un problema", "Error al eliminar", "success");
        }
    });
}