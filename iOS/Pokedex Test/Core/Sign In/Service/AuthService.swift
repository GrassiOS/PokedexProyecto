//
//  AuthService.swift
//  Pokedex Test
//
//  Created by Martin on 05/11/23.
//

import Foundation
import Combine

class AuthService {
    @Published var userSession: User?
    
    static let shared = AuthService()
    
    let session: URLSession = {
            let sessionConfig = URLSessionConfiguration.default
            return URLSession(configuration: sessionConfig, delegate: SelfSignedCertificateDelegate(), delegateQueue: nil)
        }()
    
    init() {
        self.userSession = loadUserSession()
    }
    
    
    @MainActor
    func loginUser(email: String, password: String) async throws {
            guard !email.isEmpty, !password.isEmpty else {
                print("Empty email or password")
                return
            }
            
            let endpoint = "https://127.0.0.1:7172/api/User/Email/\(email)/Password/\(password)"
            
            // Create a URL from the endpoint
            guard let url = URL(string: endpoint) else {
                print("URL problem")
                return
            }
            
            do {
                let (data, _) = try await session.data(from: url)
                
                if let usuario = try? JSONDecoder().decode(User.self, from: data) {
                    if usuario.id > 0 {
                        userSession = usuario
                        print(userSession)
                        saveUserSession(usuario)
                    }
                }
            } catch {
                print("DEBUG: Error trying to log in user: \(error.localizedDescription)")
            }
        }

        // Rest of the AuthService class as in the previous example...
    @MainActor
        func registerUser(email: String, password: String, username: String) async throws {
            guard !email.isEmpty, !password.isEmpty, !username.isEmpty else {
                print("Empty email, password, or username")
                return
            }
            
            // Construct the registration endpoint URL
            let endpoint = "https://127.0.0.1:7172/api/User"
            guard let url = URL(string: endpoint) else {
                print("URL problem")
                return
            }
            
            // Create a JSON payload for user registration
            let registrationData: [String: Any] = [
                "email": email,
                "password": password,
                "username": username
            ]
            
            do {
                // Serialize the JSON payload
                let jsonData = try JSONSerialization.data(withJSONObject: registrationData, options: [])
                
                // Create a URLRequest with the registration data
                var request = URLRequest(url: url)
                request.httpMethod = "POST"
                request.setValue("application/json", forHTTPHeaderField: "Content-Type")
                request.httpBody = jsonData
                
                // Send the registration request
                let (data, _) = try await session.data(for: request)
                
                if let usuario = try? JSONDecoder().decode(User.self, from: data) {
                    if usuario.id > 0 {
                        userSession = usuario
                        saveUserSession(usuario)
                    }
                }
            } catch {
                print("DEBUG: Error trying to register user: \(error.localizedDescription)")
            }
        }
    
    @MainActor
    func addPokemon(userID: Int, pokeID: Int) async throws {
        
        // Construct the registration endpoint URL
        let endpoint = "https://127.0.0.1:7172/api/User/\(userID)/Poke/\(pokeID)"
        guard let url = URL(string: endpoint) else {
            print("URL problem")
            return
        }
        
        do {
            
            // Create a URLRequest with the registration data
            var request = URLRequest(url: url)
            request.httpMethod = "POST"
            request.setValue("application/json", forHTTPHeaderField: "Content-Type")
            
            // Send the registration request
            let (data, _) = try await session.data(for: request)
            
        } catch {
            print("DEBUG: Error trying to register user: \(error.localizedDescription)")
        }
    }
    
    @MainActor
    func removePokemon(userID: Int, pokeID: Int) async throws {
        
        // Construct the registration endpoint URL
        let endpoint = "https://127.0.0.1:7172/api/User/\(userID)/Poke/\(pokeID)"
        guard let url = URL(string: endpoint) else {
            print("URL problem")
            return
        }
        
        do {
            
            // Create a URLRequest with the registration data
            var request = URLRequest(url: url)
            request.httpMethod = "DELETE"
            request.setValue("application/json", forHTTPHeaderField: "Content-Type")
            
            // Send the registration request
            let (data, _) = try await session.data(for: request)
            
        } catch {
            print("DEBUG: Error trying to register user: \(error.localizedDescription)")
        }
    }
        /*
        func loadUserData() async throws {
            do {
                // Make a network request to your custom API to load user data
                let userData = try await fetchUserData()
                // Update the user session with the fetched data
                //self.userSession?.update(with: userData)
            } catch {
                print("DEBUG: Error trying to load user data: \(error.localizedDescription)")
            }
        }
         */
        
    func logoutUser() {
        // Clear user session information in your app
        self.userSession = nil
        clearUserSession() // Clear the saved user session
    }
        
        // Store the user session in UserDefaults
        private func saveUserSession(_ user: User) {
            do {
                let userData = try JSONEncoder().encode(user)
                UserDefaults.standard.set(userData, forKey: "userSession")
            } catch {
                print("DEBUG: Error saving user session: \(error.localizedDescription)")
            }
        }
        
    /*
        func fetchUserData() async throws -> UserData {
            // Implement your custom API request to fetch user data here
            // Return user data in a suitable format
            return UserData() // Replace with actual user data
        }
         */
    
        private func loadUserSession() -> User? {
            guard let userData = UserDefaults.standard.data(forKey: "userSession") else {
                return nil
            }
            
            do {
                let user = try JSONDecoder().decode(User.self, from: userData)
                return user
            } catch {
                print("DEBUG: Error loading user session: \(error.localizedDescription)")
                return nil
            }
        }
        
        private func clearUserSession() {
            UserDefaults.standard.removeObject(forKey: "userSession")
        }
}
