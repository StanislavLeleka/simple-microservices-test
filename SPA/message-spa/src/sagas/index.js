import { takeEvery, all, call } from 'redux-saga/effects';
import MessageApi from '../api/message-api';
import { SEND_MESSAGE } from '../constants';

function* sendMessage(action) {
    yield call(MessageApi.sendMessage, action.message, action.url);
}

function* watchSendMessage() {
    yield takeEvery(SEND_MESSAGE, sendMessage);
}

export default function* rootSaga(){
    yield all([
        watchSendMessage()
    ])
}