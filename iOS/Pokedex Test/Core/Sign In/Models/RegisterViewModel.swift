//
//  RegisterViewModel.swift
//  Pokedex Test
//
//  Created by Martin on 05/11/23.
//

import Foundation

class RegisterViewModel: ObservableObject {
    @Published var username = ""
    @Published var email = ""
    @Published var password = ""
    
    func createUser() async throws
    {
        try await AuthService.shared.registerUser(email: email, password: password, username: username)
        username = ""
        email = ""
        password = ""
    }
}
