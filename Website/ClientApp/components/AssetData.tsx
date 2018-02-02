import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface CounterState {
    assets: Asset[];
    loading: boolean;
}

export class AssetData extends React.Component<RouteComponentProps<{}>, CounterState> {
    constructor() {
        super();
        this.state = { assets: [], loading: true };

        fetch('api/Asset/GetAssetData')
            .then(response => response.json() as Promise<Asset[]>)
            .then(data => {
                this.setState({ assets: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AssetData.renderAssetTable(this.state.assets);

        return <div>
            <h1>Assets</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>;
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