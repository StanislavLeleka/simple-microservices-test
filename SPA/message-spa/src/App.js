import React, { Component } from 'react';
import { createStore, applyMiddleware } from 'redux';
import rootSaga from './sagas';
import { messagesReducer } from './reducers';
import createSagaMiddleware from 'redux-saga';
import { Provider } from 'react-redux';
import './App.css';
import SendMessage from './components/send-message';
import Notifications from './components/notitfications';

const sagaMiddleware = createSagaMiddleware();
const store = createStore(messagesReducer, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__(), applyMiddleware(sagaMiddleware));

sagaMiddleware.run(rootSaga);

class App extends Component {
  render() {
    return (
      <Provider store={store}>
        <div className="message-container">
          <SendMessage />
          <Notifications />
        </div>
      </Provider>
    );
  }
}

export default App;
