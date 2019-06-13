$(function () {
    $('.select2').select2();

    if (mkey === '') {
        mkey = '/';
    }
    console.log(mkey);
    $('[data-key="' + mkey + '"]').addClass('active');
});