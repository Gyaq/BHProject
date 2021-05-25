$(document).ready(function () {   

    $.ajax({
        url: apiUri +'/Json/GetListData'
    }).then(function (data) {
       var allData = JSON.parse(data);
        buildList(allData);
    }).fail(function (jqHXR, status, error) {
        alert("There was an error getting all reasons.");
    });    

    function buildList(data) {
        var reasons = data.reasons;
        var users = data.users;

        var listItem = '';

        $.each(reasons, function (index, reason) {

            var user = users.find(x => x.Id === reason.CreatedBy);

            listItem += `  <div class="reason-container">
                  <div class="reason">
                      <div class="reason-preview">
                          <h6><img src="${user.ImageUrl}" /></h6>
                          <h2>${user.FirstName} ${user.LastName}</h2>

                      </div>
                      <div class="reason-info">

                          <h2>${reason.ReasonTitle}</h2>
                          <h6>${reason.ReasonDescription}</h6>
                      </div>
                  </div>
              </div>`;

        });


        $(".Content").append(listItem);
    }
});