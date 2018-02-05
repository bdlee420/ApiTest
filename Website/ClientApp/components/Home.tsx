import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Test API</h1>
            <p>Test solution to show service interaction inside the website</p>           
        </div>;
    }
}
