//
//  MainAppView.swift
//  Pokedex Test
//
//  Created by Martin on 22/11/23.
//

import SwiftUI

struct MainAppView: View {
    let user: User
    var body: some View {
        Text(/*@START_MENU_TOKEN@*/"Hello, World!"/*@END_MENU_TOKEN@*/)
    }
}

#Preview {
    MainAppView(user: User.MOCK_USERS[1])
}
