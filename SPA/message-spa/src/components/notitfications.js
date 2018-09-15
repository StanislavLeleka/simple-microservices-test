import * as React from 'react';
import { connect } from 'react-redux';
import { receiveNotification } from '../actions';

const notificationServiceHost = "http://localhost:32768";
const signalR = require("@aspnet/signalr");
const connection = new signalR.HubConnectionBuilder().withUrl(notificationServiceHost + "/messageHub").build();

class Notifications extends React.Component {
    constructor(props){
        super(props);
        
        connection.on("ReceiveMessage", function (recipient, body) {
            props.receiveNotification({
                recipient,
                body
            });
        });

        connection.start().catch(function (err) {
            return console.error(err.toString());
        });
    }

    render() {
        return (
        <div className="notifications-container">
            <h2>Notifications</h2>
            <ul className="list-group">
                {
                    this.props.notifications.map((n, i) => {
                        return (
                            <li className="list-group-item" key={i}>
                                Body: {n.body}, Recipient: {n.recipient}
                            </li>
                        )
                    })
                }
            </ul>
        </div>
        );
    }
}

const mapStateToProps = state => ({
  notifications: state.notifications
});

const mapDispatchToProps = (dispatch) => ({
  receiveNotification: (notification) => dispatch(receiveNotification(notification))
});

export default connect(mapStateToProps, mapDispatchToProps)(Notifications)