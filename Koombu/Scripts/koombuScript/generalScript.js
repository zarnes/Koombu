﻿function addGroup() {

    $.ajax({
        type: "GET",
        url: '/Views/Modal/addGroupModalView.html',
        success: function (msg) {
            $("#getModal").empty();
            $("#getModal").html(msg);
            $("#adGroupModal").modal("show");
        }
    })
}

function postView(picture, title, content) {

    $.ajax({
        type: "GET",
        url: '/Views/Modal/showPostModalView.html',
        success: function (msg) {
            $("#getModal").empty();
            $("#getModal").html(msg);
            $("#showPostModal").modal("show");
        }
    })
}

function addPost() {
    $.ajax({
        type: "GET",
        url: '/Views/Modal/addPostModalView.html',
        success: function (msg) {
            $("#getModal").empty();
            $("#getModal").html(msg);
            $("#createPostModal").modal("show");
        }
    })
}