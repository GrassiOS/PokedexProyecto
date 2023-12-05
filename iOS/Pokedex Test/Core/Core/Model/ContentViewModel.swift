//
//  ContentViewModel.swift
//  Pokedex Test
//
//  Created by Martin on 05/11/23.
//

import SwiftUI
import Combine

@MainActor
class ContentViewModel: ObservableObject {
    private let service = AuthService.shared
    private var cancellables = Set<AnyCancellable>()
    
    @Published var userSession: User?
    
    init() {
        setupSubscribers()
    }
    
    func setupSubscribers() {
        service.$userSession.sink { [weak self] userSession in
            self?.userSession = userSession
        }
        .store(in: &cancellables)
    }
    
    func loginUser(email: String, password: String) async throws {
        try await service.loginUser(email: email, password: password)
    }
    
    func logoutUser() {
        service.logoutUser()
    }
}
