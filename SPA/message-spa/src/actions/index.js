import { SEND_MESSAGE, RECEIVE_NOTIFIFCATION } from '../constants'

export function sendMessage(message, url) {
    return {
        type: SEND_MESSAGE,
        message,
        url
    }
}

export function receiveNotification(notification) {
    return {
        type: RECEIVE_NOTIFIFCATION,
        notification
    }
}