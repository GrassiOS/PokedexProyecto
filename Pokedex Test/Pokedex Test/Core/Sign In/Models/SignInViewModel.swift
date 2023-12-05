//
//  SignInViewModel.swift
//  Pokedex Test
//
//  Created by Martin on 04/11/23.
//
//

import Foundation

//@MainActor
class SigninViewModel: ObservableObject {
    @Published var email = ""
    @Published var password = ""

    func loginUser() async throws
    {
        try await AuthService.shared.loginUser(email: email, password: password)
    }
}
