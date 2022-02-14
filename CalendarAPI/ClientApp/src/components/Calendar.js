import React, { Component } from 'react';
import moment from 'moment';
import { ReactAgenda, ReactAgendaCtrl, guid, getUnique, getLast, getFirst, Modal } from 'react-agenda';

var now = new Date();
const URL_BASE = process.env.REACT_APP_URL_BASE
require('moment/locale/fr.js');
var colors = {
    'color-1': "rgba(102, 195, 131 , 1)",
    "color-2": "rgba(242, 177, 52, 1)",
    "color-3": "rgba(235, 85, 59, 1)",
    "color-4": "rgba(70, 159, 213, 1)",
    "color-5": "rgba(170, 59, 123, 1)"
}



var items = [];

export class Agenda extends Component {
    constructor(props) {
        super(props);



        this.state = {
            items: [],
            selected: [],
            cellHeight: (60 / 4),
            showModal: false,
            rowsPerHour: 4,
            numberOfDays: 4,
            startDate: new Date(),
            email: "",
            password: "",
            token: ""
        }
        this.handleRangeSelection = this.handleRangeSelection.bind(this)
        this.handleItemEdit = this.handleItemEdit.bind(this)
        this.zoomIn = this.zoomIn.bind(this)
        this.zoomOut = this.zoomOut.bind(this)
        this._openModal = this._openModal.bind(this)
        this._closeModal = this._closeModal.bind(this)
        this.addNewEvent = this.addNewEvent.bind(this)
        this.removeEvent = this.removeEvent.bind(this)
        this.editEvent = this.editEvent.bind(this)
        this.changeView = this.changeView.bind(this)
        this.handleCellSelection = this.handleCellSelection.bind(this)
        this.handleSubmit = this.handleSubmit.bind(this)
        this.inputUsername = this.inputUsername.bind(this)
        this.inputPassword = this.inputPassword.bind(this)

    }

    componentDidMount() {

        this.setState({ items: items })


    }


    componentWillReceiveProps(next, last) {
        if (next.items) {

            this.setState({ items: next.items })
        }
    }
    handleItemEdit(item, openModal) {

        if (item && openModal === true) {
            this.setState({ selected: [item] })
            return this._openModal();
        }




    }
    handleCellSelection(item, openModal) {

        if (this.state.selected && this.state.selected[0] === item) {
            return this._openModal();
        }
        this.setState({ selected: [item] })

    }

    zoomIn() {
        var num = this.state.cellHeight + 15
        this.setState({ cellHeight: num })
    }
    zoomOut() {
        var num = this.state.cellHeight - 15
        this.setState({ cellHeight: num })
    }


    handleDateRangeChange(startDate, endDate) {
        this.setState({ startDate: startDate })

    }

    async  handleSubmit(event) {
        event.preventDefault();
        const bodyData = {
            email: this.state.email,
            password: this.state.password
        }
        const response = await fetch(URL_BASE + "/api/Auth", {
            method: "post", headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }, body: JSON.stringify(bodyData) });
        if (!response.ok) {
            alert("Email/Password wrongs")
        }
        else {
            const data = await response.json()
            this.setState({ token: data["token"] })
          
            const responseEvents = await fetch(URL_BASE + "/api/calendar/events", {
                method: "get", headers: {
                    'Authorization': 'Bearer ' + this.state.token,
                }
            });
            if (responseEvents.ok) {
                const dataEvents = await responseEvents.json()
                let events = []
                dataEvents.forEach(element => {
                    const event = {
                        _id: element.id,
                        name: element.name,
                        startDateTime: new Date(element.dateStart),
                        endDateTime: new Date(element.dateEnd),
                        classes: 'color-2'
                    };
                    events.push(event)
                })
                this.setState({ items: events})
            }
            else {
                alert("Não foi possivel recuperar")
            }

        }
        this.setState({ email: "" })
        this.setState({ password: "" })
       
    }

    handleRangeSelection(selected) {


        this.setState({ selected: selected, showCtrl: true })
        this._openModal();

    }

    _openModal() {
        this.setState({ showModal: true })
    }

   
    _closeModal(e) {
        if (e) {
            e.stopPropagation();
            e.preventDefault();
        }
        this.setState({ showModal: false })
    }

    inputUsername(e) {
        this.setState({ email: e.target.value })
    }

    inputPassword(e) {
        this.setState({ password: e.target.value })
    }

    handleItemChange(items, item) {
        this.setState({ items: items })
    }

    handleItemSize(items, item) {

        this.setState({ items: items })

    }

    addUsername(username, usernam) {
        this.setState({ items: items })
    }

    async removeEvent(items, item) {
        const responseEvents = await fetch(URL_BASE + "/api/calendar/events/" + item["_id"], {
            method: "DELETE", headers: {
                'Authorization': 'Bearer ' + this.state.token,
            }
        });
        if (responseEvents.ok) {
            this.setState({ items: items });
        }
        else {
            alert("Wrong to delete")
        }
    }

    async addNewEvent(items, newItems) {
        let eventToAdd = {
            name: newItems["name"],
            calendar: "root",
            dateStart: newItems["startDateTime"],
            dateEnd: newItems["endDateTime"],
            id: newItems["_id"]
        }
        const responseCreateEvent = await fetch(URL_BASE + "/api/calendar/events", {
            method: "post", headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + this.state.token,
            }, body: JSON.stringify(eventToAdd)
        });
        if (responseCreateEvent.ok) {
            this.setState({ items: items });
        }
        else {
            alert("Error in add new event");
        }
        this.setState({ showModal: false, selected: []});
        this._closeModal();
    }
    async editEvent(items, item) {
        let eventUpdate = {
            name: item["name"],
            dateStart: item["startDateTime"],
            dateEnd: item["endDateTime"],
        }

        const responsUpdateEvent = await fetch(URL_BASE + "/api/calendar/events/" + item["_id"] , {
            method: "put", headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + this.state.token,
            }, body: JSON.stringify(eventUpdate)
        });
        if (responsUpdateEvent.ok) {
            this.setState({ items: items });
        }
        else {
            alert("Error in update event");
        }
        this.setState({ showModal: false, selected: [], items: items });
        this._closeModal();
    }

    changeView(days, event) {
        this.setState({ numberOfDays: days })
    }


    render() {

        var AgendaItem = function (props) {
            console.log(' item component props', props)
            return <div style={{ display: 'block', position: 'absolute', background: '#FFF' }}>{props.item.name} <button onClick={() => props.edit(props.item)}>Edit </button></div>
        }
        return (

            <div className="content-expanded ">
                <form onSubmit={this.handleSubmit}>
                    <label>Enter your email:
                    <input
                            type="text"
                            value={this.state.email}
                            onChange={this.inputUsername}
                        />
                    </label>

                    <label>Enter your pasword:
                    <input
                            type="password"
                            value={this.state.password}
                            onChange={this.inputPassword}
                        />
                    </label>
                    <input type="submit" />
                </form>
                <div className="control-buttons">
                    <button className="button-control" onClick={this.zoomIn}> <i className="zoom-plus-icon"></i> </button>
                    <button className="button-control" onClick={this.zoomOut}> <i className="zoom-minus-icon"></i> </button>
                    <button className="button-control" onClick={this._openModal}> <i className="schedule-icon"></i> </button>
                    <button className="button-control" onClick={this.changeView.bind(null, 7)}> {moment.duration(7, "days").humanize()}  </button>
                    <button className="button-control" onClick={this.changeView.bind(null, 4)}> {moment.duration(4, "days").humanize()}  </button>
                    <button className="button-control" onClick={this.changeView.bind(null, 3)}> {moment.duration(3, "days").humanize()}  </button>
                    <button className="button-control" onClick={this.changeView.bind(null, 1)}> {moment.duration(1, "day").humanize()} </button>
                </div>

                <ReactAgenda
                    minDate={new Date(now.getFullYear(), now.getMonth() - 3)}
                    maxDate={new Date(now.getFullYear(), now.getMonth() + 3)}
                    startDate={this.state.startDate}
                    startAtTime={8}
                    endAtTime={23}
                    cellHeight={this.state.cellHeight}
                    items={this.state.items}
                    numberOfDays={this.state.numberOfDays}
                    headFormat={"ddd DD MMM"}
                    rowsPerHour={this.state.rowsPerHour}
                    itemColors={colors}
                    helper={true}
                    //itemComponent={AgendaItem}
                    view="calendar"
                    autoScale={false}
                    fixedHeader={true}
                    onRangeSelection={this.handleRangeSelection.bind(this)}
                    onChangeEvent={this.handleItemChange.bind(this)}
                    onChangeDuration={this.handleItemSize.bind(this)}
                    onItemEdit={this.handleItemEdit.bind(this)}
                    onCellSelect={this.handleCellSelection.bind(this)}
                    onItemRemove={this.removeEvent.bind(this)}
                    onDateRangeChange={this.handleDateRangeChange.bind(this)} />
                {
                    this.state.showModal ? <Modal clickOutside={this._closeModal} >
                        <div className="modal-content">
                            <ReactAgendaCtrl items={this.state.items} itemColors={colors} selectedCells={this.state.selected} Addnew={this.addNewEvent} edit={this.editEvent} />

                        </div>
                    </Modal> : ''
                }


            </div>

        );
    }
}