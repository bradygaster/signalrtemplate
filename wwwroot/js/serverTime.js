var clockConnection = new signalR.HubConnectionBuilder().withUrl("/serverTime").build();

var updateServerTime = function (serverTime) {
    document.getElementById("serverTime").innerText =
        new Date(serverTime).toLocaleTimeString();
};

clockConnection.on("SendTime", updateServerTime);

clockConnection.start().then(function () {
    // do your own post-connection-started work here
}).catch(function (err) {
    return console.error(err.toString());
});