import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataExampleState {
    funds: Fund[];
    loading: boolean;
}

export class FundData extends React.Component<RouteComponentProps<{}>, FetchDataExampleState> {
    constructor() {
        super();
        this.state = { funds: [], loading: true };

        fetch('api/Fund/GetFundData')
            .then(response => response.json() as Promise<Fund[]>)
            .then(data => {
                this.setState({ funds: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FundData.renderFundTable(this.state.funds);

        return <div>
            <h1>Funds</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>;
    }

    private static renderFundTable(funds: Fund[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Description</th>
                </tr>
            </thead>
            <tbody>
                {funds.map(fund =>
                    <tr key={fund.id}>
                        <td>{fund.id}</td>
                        <td>{fund.name}</td>
                        <td>{fund.description}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface Fund {
    id: number;
    name: string;
    description: string;
}
