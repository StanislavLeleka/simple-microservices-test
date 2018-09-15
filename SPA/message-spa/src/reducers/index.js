import { RECEIVE_NOTIFIFCATION } from '../constants';

const initialState = {
    notifications: []
}

export function messagesReducer(state = initialState, action) {
    switch (action.type) {
        case RECEIVE_NOTIFIFCATION:
        {
            var notifications = [...state.notifications];            
            notifications.push(action.notification);

            return {
                notifications
            }
        }
        default:
            return state;
    }
}