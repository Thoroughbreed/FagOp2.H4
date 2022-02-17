// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Old homebrewed modal script
// $(function () {
//     var placeholderElement = $('#modal-placeholder');
//
//     $('button[data-toggle="modal"]').click(function (event) {
//         var url = $(this).data('url');
//         $.get(url).done(function (data) {
//             placeholderElement.html(data);
//             placeholderElement.find('.modal').modal('show');
//         });
//     });
//
//     placeholderElement.on('click', '[data-save="modal"]', function (event) {
//         event.preventDefault();
//
//         var form = $(this).parents('.modal').find('form');
//         var actionUrl = form.attr('action');
//         var dataToSend = form.serialize();
//
//         $.post(actionUrl, dataToSend).done(function (data) {
//             var newBody = $('.modal-body', data);
//             placeholderElement.find('.modal-body').replaceWith(newBody);
//
//             var isValid = newBody.find('[name="IsValid"]').val();// == 'True';
//             if (isValid) {
//                 placeholderElement.find('.modal').modal('hide');
//             }
//         });
//     });
//
//     placeholderElement.on('click', '[data-save="modal"]', function (event) {
//         event.preventDefault();
//
//         var form = $(this).parents('.modal').find('form');
//         var actionUrl = form.attr('action');
//         var sendData = form.serialize();
//
//         $.post(actionUrl, sendData).done(function (data) {
//             placeholderElement.find('.modal').modal('hide');
//         });        
//     });
//
//
//     placeholderElement.on('click', '[data-dismiss="modal"]', function (event) {
//         event.preventDefault();
//         placeholderElement.find('.modal').modal('hide');
//     });
// });


// bootstrap modal template
$('#editModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var itemID = button.data('id') 
    var itemPrio = button.data('prio') 
    var itemDesc = button.data('desc')

    var modal = $(this)
    
    // if (itemPrio == "Low") itemPrio = 0
    // if (itemPrio == "Normal") itemPrio = 1
    // if (itemPrio == "High") itemPrio = 2
    
    // modal.find('.modal-title').text(itemID + " " + itemPrio + " " + itemDesc)
    modal.find('.item-id').val(itemID)
    modal.find('.item-description').val(itemDesc)
    modal.find('.item-priority').val(itemPrio) 
})

$('#deleteModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var itemID = button.data('id')
    var itemDesc = button.data('desc')
    
    var modal = $(this)
    modal.find('.item-id').val(itemID)
    modal.find('.item-description').val(itemDesc)
})