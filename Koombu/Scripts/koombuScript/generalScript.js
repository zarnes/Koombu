function addGroup() {

    $.ajax({
        type: "GET",
        url: '/Views/Modal/addGroupModalView.html',
        success: function (msg) {
            $("#getModal").empty();
            $("#getModal").html(msg);
            $("#addGroupModal").modal("show");
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

function addPost(group_id) {
    $.ajax({
        type: "GET",
        data : "group_id="+group_id,
        url: '/Views/Modal/addPostModalView.html',
        success: function (msg) {
            $("#getModal").empty();
            $("#getModal").html(msg);
            $("#addPostModalView").modal("show");

            $("#addPostModalView form").on('submit', function () {
                $(".groupId").val(group_id);
            });
        }
    })
}


function addUserToGroup(groupId) {
    $.ajax({
        type: "GET",
        url: '/Views/Modal/addUserToGroupModalView.html',
        data: '?group_id=' + groupId,
        success: function (msg) {
            $("#getModal").empty();
            $("#getModal").html(msg);
            $("#addUserToGroupModal").modal("show");
            $("#addUserToGroupModal form").on('submit', function () {
                $(".groupId").val(group_id);
            });
        }
    })
}