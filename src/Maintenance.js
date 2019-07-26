/* eslint-disable no-unused-expressions */
import React from 'react';
import { Table, Container } from 'react-bootstrap';
import Axios from 'axios';

class Maintenance extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            maintenanceArray: []
        };
    }

    componentDidMount() {
        this.loadPartData();
    }

    /**
     * @summary API Call #4: Perform a GET call to the API for maintenance data
     */
    loadPartData() {
        Axios.get("https://webapi20190630041009.azurewebsites.net/api/maintenance")
            .then((response) => {
                // Store the list of maintenance entries in the
                // component state
                this.setState({ maintenanceArray: response.data });
            });
    }

    render() {
        return (
            <Container>
                <h1 mb="0">Maintenance</h1>
                <p>This list contains maintenance information.</p>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Service Performed</th>
                            <th>Total Cost</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            // Iterate over the maintenance array and create a
                            // table row for each entry.
                            this.state.maintenanceArray.splice(0, 15).map((entry, index) => 
                                <tr key={`entry-${index}`}>
                                    <td>{entry.date}</td>
                                    <td>{entry.servicePerformed}</td>
                                    <td>{entry.totalCost}</td>
                                </tr>
                            )
                        }
                    </tbody>
                </Table>
            </Container>
        );
    }
}

export default Maintenance;