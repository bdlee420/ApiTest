import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AssetData } from './components/AssetData';
import { FundData } from './components/FundData';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/assetdata' component={ AssetData } />
    <Route path='/funddata' component={ FundData } />
</Layout>;
