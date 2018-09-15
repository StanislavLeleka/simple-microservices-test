import * as React from 'react';
import { connect } from 'react-redux';
import { sendMessage } from '../actions';

class SendMessage extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            subject: "",
            body: "",
            recipients: "",
            url: ""
        };
    }

    onInputTextChange(e) {
        this.setState({[e.target.name]: e.target.value});
    }

    onSend() {
        this.props.send({
            subject: this.state.subject,
            body: this.state.body,
            recipients: this.state.recipients.split(',')
        }, this.state.url);
    }

    render() {
        return (
        <div className="new-message-container">
            <h2>New message</h2>
            <div className="form-group">
                <label htmlFor="subject">Subject:</label>
                <input type="text" className="form-control" id="subject" placeholder="Enter subject" name="subject" 
                    onChange={(e) => this.onInputTextChange(e)}/>
            </div>
            <div className="form-group">
                <label htmlFor="body">Body:</label>
                <input type="text" className="form-control" id="body" placeholder="Enter body" name="body" 
                    onChange={(e) => this.onInputTextChange(e)}/>
            </div>
            <div className="form-group">
                <label htmlFor="recipients">Recipients:</label>
                <input type="text" className="form-control" id="recipients" placeholder="Enter recipients separated by comma" name="recipients" 
                    onChange={(e) => this.onInputTextChange(e)}/>
            </div>
            <div className="form-group">
                <label htmlFor="url">Service url:</label>
                <input type="text" className="form-control" id="url" placeholder="Enter message service host url" name="url"
                    onChange={(e) => this.onInputTextChange(e)}/>
            </div>
            <button className="btn btn-primary"
                onClick={() => this.onSend()}>Send</button>
        </div>
        );
    }
}

const mapDispatchToProps = (dispatch) => ({
  send: (message, url) => dispatch(sendMessage(message, url))
})

export default connect(null, mapDispatchToProps)(SendMessage)