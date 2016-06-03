// item selection
$('.image-selector li').click(function () {
  $(this).toggleClass('selected');
  if ($('li.selected').length == 0)
    $('.select').removeClass('selected');
  else
    $('.select').addClass('selected');
  counter();
});

// all item selection
$('.image-selector .select').click(function () {
    if ($('.image-selector li.selected').length == 0) {
        $('.image-selector li').addClass('selected');
        $('.image-selector .select').addClass('selected');
  }
  else {
        $('.image-selector li').removeClass('selected');
        $('.image-selector .select').removeClass('selected');
  }
  counter();
});

// number of selected items
function counter() {
    if ($('.image-selector li.selected').length > 0)
        $('.image-selector .send').addClass('selected');
  else
        $('.image-selector .send').removeClass('selected');
    $('.image-selector .send').attr('data-counter', $('.image-selector li.selected').length);
}


