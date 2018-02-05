import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface CounterState {
    assets: Asset[];
    loading: boolean;
    searchString: string;
}

export class SearchAssetData extends React.Component<RouteComponentProps<{}>, CounterState> {
    constructor() {
        super();
        this.state =
            {
                assets: [],
                loading: true,
                searchString: ''
            };

        this.loadData("");
    }

    public loadData(searchString: string) {
        fetch(`api/Asset/SearchAssetData?name=${searchString}`)
            .then(response => response.json() as Promise<Asset[]>)
            .then(data => {
                this.setState({ assets: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : SearchAssetData.renderAssetTable(this.state.assets);

        return <div>
            <h1>Assets</h1>
            <p>Search Assets by Name</p>
            <input
                type="text"
                value={this.state.searchString}
                onChange={this.handleChange.bind(this)}
                onBlur={this.handleBlur.bind(this)} >
            </input>
            {contents}
        </div>;
    }

    handleChange(e: any) {
        this.setState({ searchString: e.target.value });
    }

    handleBlur(e: any) {
        this.loadData(e.target.value);
    }

    private static renderAssetTable(assets: Asset[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Description</th>
                </tr>
            </thead>
            <tbody>
                {assets.map(asset =>
                    <tr key={asset.id}>
                        <td>{asset.id}</td>
                        <td>{asset.name}</td>
                        <td>{asset.description}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface Asset {
    id: number;
    name: string;
    description: string;
}