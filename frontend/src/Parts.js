/* eslint-disable no-unused-expressions */
import React from 'react';
import { Table, Container } from 'react-bootstrap';
import Axios from 'axios';

class Parts extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            partsArray: [],
            term: ""
        };
    }

    componentDidMount() {
        this.loadPartData();
    }

    /**
     * @summary API Call #3: Perform a GET call to the API for parts data
     */
    loadPartData() {
        Axios.get("http://localhost:5000/parts")
            .then((response) => {
                // Store the list of maintenance entries in the
                // component state
                console.log(response.data);
                this.setState({ partsArray: response.data });
            });
    }

    /**
     * @summary API Call: Perform a GET call to the API to search parts data
     */
    searchPartData(term) {
        Axios.get(`http://localhost:5000/parts/search/${term}`)
            .then((response) => {
                // Store the list of maintenance entries in the
                // component state
                this.setState({ partsArray: response.data });
            });
    }

    onSubmit = (event) => {
        // Don't let the form submit, only a mechanism to allow submit button behavior
        event.preventDefault();

        // Don't search if we didn't enter a term
        if (!this.state.term) {
            return;
        }

        this.searchPartData(this.state.term)
    };

    onReset = (event) => {
        // Don't let the form do anything
        event.preventDefault();

        // Reset term and part data
        this.setState({ term: "" }, () => this.loadPartData());
    }

    render() {
        return <Container>
            <h1>Parts</h1>
            <p>An API was created for this project and is hosted on a temporary Azure account.  This parts list, containing real parts information created from my real-life Isuzu VehiCross restoration project, is being generated via an API Call.
            This is API Call #3.</p>
            <div>
                <form onSubmit={this.onSubmit} onReset={this.onReset}>
                    <label>Search:
                        <input
                            type="text"
                            value={this.state.term}
                            onChange={(event) => this.setState({ term: event.target.value })}
                        />
                    </label>
                    <button type="submit">Search</button>
                    {this.state.term && 
                        <button type="reset">Reset</button>
                    }
                </form>
            </div>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Part Number</th>
                        <th>Supplier</th>
                        <th>Price</th>
                        <th>Notes</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.partsArray.slice(0, 15).map((part, index) => 
                        <tr key={`part-${index}`}>
                            <td>{part.Part}</td>
                            <td>{part.partNumber}</td>
                            <td>{part.supplier}</td>
                            <td>${part['Unit Price']}</td>
                            <td>{part.notes}</td>
                        </tr>
                    )}
                </tbody>
            </Table>
        </Container>
    }
}

export default Parts;