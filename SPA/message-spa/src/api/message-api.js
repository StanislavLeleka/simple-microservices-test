export default class MessageApi {
    static sendMessage(message, url) {
        return apiRequest(url + "/api/messages/send", "POST", message);
    }
}

function apiRequest(url, method, data){
    return fetch(url, {
        method: method,
        body: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json",
            "Access-Control-Allow-Origin": "*"
        }
    }).then((response) => (response.json()))
    .then((response) => ({ response }))
    .catch(error => ({ error }));
}